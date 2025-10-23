using AirportDataGridView.Classes;
using System.ComponentModel.DataAnnotations;

namespace AirportDataGridView.Models
{
    /// <summary>
    /// Класс модели записи
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// Свойство номера рейса
        /// </summary>
        [Required]
        public int FlightNum { get; set; }

        /// <summary>
        /// Свойство типа самолета
        /// </summary>
        [Required]
        public PlaneType PlaneType { get; set; }

        /// <summary>
        /// Свойство времени прибытия
        /// </summary>
        [Required]
        public DateTime Arrive { get; set; }

        /// <summary>
        /// Свойство числа пассажиров
        /// </summary>
        [Required]
        [Display(Name = "Число пассажиров")]
        [Range(Constants.PassengersAmountMinValue, Constants.PassengersAmountMaxValue, ErrorMessage = "{0} должно быть в пределе от {1} до {2}")]
        public int PassengersAmount { get; set; }

        /// <summary>
        /// Свойство надбавки на пассажира
        /// </summary>
        [Required]
        [Display(Name = "Надбавка за пассажира")]
        [Range(Constants.PassengersFeeMinValue, Constants.PassengersFeeMaxValue, ErrorMessage = "{0} должно быть в пределе от {1} до {2}")]
        public float PassengersFee { get; set; }

        /// <summary>
        /// Свойство числа экипажа
        /// </summary>
        [Required]
        [Display(Name = "Число экипажа")]
        [Range(Constants.CrewAmountMinValue, Constants.CrewAmountMaxValue, ErrorMessage = "{0} должно быть в пределе от {1} до {2}")]
        public int CrewAmount { get; set; }

        /// <summary>
        /// Свойство надбавки за экипаж
        /// </summary>
        [Required]
        [Display(Name = "Надбавка за экипаж")]
        [Range(Constants.CrewFeeMinValue, Constants.CrewFeeMaxValue, ErrorMessage = "{0} должно быть в пределе от {1} до {2}")]
        public float CrewFee { get; set; }

        /// <summary>
        /// Свойство процента надбавки
        /// </summary>
        [Required]
        [Display(Name = "Процент надбавки")]
        [Range(Constants.MarkupMinValue, Constants.MarkupMaxValue, ErrorMessage = "{0} должно быть в пределе от {1} до {2}")]
        public float Markup { get; set; }

        /// <summary>
        /// Вычисляемое свойство выручки
        /// </summary>
        public float Revenue
        {
            get
            {
                var result = (PassengersAmount * PassengersFee + CrewAmount * CrewFee);
                return result * (Markup / 100) + result; // Добавление процента надбавки
            }
        }
    }
}
