using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace AirportDataGridView.Infrastructure 
{ 

    /// <summary>
    /// Класс с методами расширения.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Добавляет байндинг между свойствами двух элементов - элемента управления на форме и источником изменения данных.
        /// Данные изменяются при изменении свойств - <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
        /// Валидирует данные при передаче <see cref="ErrorProvider"/>.
        /// </summary>
        /// <typeparam name="TControl">Параметр <see cref="Control"/>, свойства которого будут меняться.</typeparam>
        /// <typeparam name="TSource">Параметр источника свойства, связанного с <see cref="Control"/></typeparam>
        /// <param name="control">Элемент управления, свойства которого привязываются к источнику.</param>
        /// <param name="source">Источник, свойства которого привязываются к элементу управления</param>
        /// <param name="destinationProperty">Выражение доступа к свойству элемента управления.</param>
        /// <param name="sourceProperty">Выражение доступа к свойству источника.</param>
        /// <param name="errorProvider">Провайдер отображения ошибок.</param>
        public static void AddBinding<TControl, TSource>(
            this TControl control,
            Expression<Func<TControl,object>> destinationProperty,
            TSource source,
            Expression<Func<TSource,object>> sourceProperty,
            ErrorProvider? errorProvider = null
            )
            where TControl : Control
            where TSource : class
        {
            var destinationPropertyName = GetPropertyName(destinationProperty);
            var sourcePropertyName = GetPropertyName(sourceProperty);

            if (control.DataBindings[destinationPropertyName]  != null)
            {
                control.DataBindings.Remove(control.DataBindings[destinationPropertyName]);
            }

            var binding = new Binding(destinationPropertyName, source, sourcePropertyName)
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };

            control.DataBindings.Add(binding);

            if (errorProvider != null)
            {
                var sourcePropertyInfo = source.GetType().GetProperty(sourcePropertyName);
                var validationAttributes = sourcePropertyInfo?.GetCustomAttributes<ValidationAttribute>();

                if (validationAttributes?.Any() == true)
                {
                    control.Validating += (_, _) =>
                    {
                        var context = new ValidationContext(source)
                        {
                            MemberName = sourcePropertyName,
                        };
                        var results = new List<ValidationResult>();

                        errorProvider.SetError(control, string.Empty);

                        var propertyValue = sourcePropertyInfo?.GetValue(source);
                        bool isValid = Validator.TryValidateProperty(propertyValue, context, results);

                        if (!isValid) 
                        { 
                            foreach (var error in results)
                            {
                                errorProvider.SetError(control, error.ErrorMessage);
                            }
                        }
                    };
                }
            }
        }

        private static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            Expression body = expression.Body;

            if (body.NodeType == ExpressionType.Convert)
            {
                body = ((UnaryExpression)body).Operand;
            }

            if (body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            throw new ArgumentException($"Выражение должно быть доступом к свойству {nameof(expression)}");
        }
    }
}
