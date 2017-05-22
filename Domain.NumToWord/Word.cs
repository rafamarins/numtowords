using System.ComponentModel.DataAnnotations;

namespace NumToWord.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Word
    {                 
        //CREATE
        /// <summary>
        /// The _number
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Number")]
        private string _number;

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public string Number { get {return this._number ;} set { this._number = value; } }
    }
}
