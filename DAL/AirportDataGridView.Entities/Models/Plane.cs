using AirportDataGridView.Constants;
using System.ComponentModel.DataAnnotations;

namespace AirportDataGridView.Entities.Models
{
    /// <summary>
    /// Класс модели записи
    /// </summary>
    public class Plane
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
        [Range(AppConstants.PassengersAmountMinValue, AppConstants.PassengersAmountMaxValue, ErrorMessage = "{0} должно быть в пределе от {1} до {2}")]
        public int PassengersAmount { get; set; }

        /// <summary>
        /// Свойство надбавки на пассажира
        /// </summary>
        [Required]
        [Display(Name = "Надбавка за пассажира")]
        [Range(AppConstants.PassengersFeeMinValue, AppConstants.PassengersFeeMaxValue, ErrorMessage = "{0} должно быть в пределе от {1} до {2}")]
        public float PassengersFee { get; set; }

        /// <summary>
        /// Свойство числа экипажа
        /// </summary>
        [Required]
        [Display(Name = "Число экипажа")]
        [Range(AppConstants.CrewAmountMinValue, AppConstants.CrewAmountMaxValue, ErrorMessage = "{0} должно быть в пределе от {1} до {2}")]
        public int CrewAmount { get; set; }

        /// <summary>
        /// Свойство надбавки за экипаж
        /// </summary>
        [Required]
        [Display(Name = "Надбавка за экипаж")]
        [Range(AppConstants.CrewFeeMinValue, AppConstants.CrewFeeMaxValue, ErrorMessage = "{0} должно быть в пределе от {1} до {2}")]
        public float CrewFee { get; set; }

        /// <summary>
        /// Свойство процента надбавки
        /// </summary>
        [Required]
        [Display(Name = "Процент надбавки")]
        [Range(AppConstants.MarkupMinValue, AppConstants.MarkupMaxValue, ErrorMessage = "{0} должно быть в пределе от {1} до {2}")]
        public float Markup { get; set; }

    }
}
