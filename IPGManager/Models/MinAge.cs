using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class MinAge : ValidationAttribute
    {
        private int _Limit;
        public MinAge(int Limit)
        { 
            this._Limit = Limit;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime bday = DateTime.Parse(value.ToString());
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            if (bday > today.AddYears(-age))
            {
                age--;
            }
            if (age < _Limit)
            {
                
                return new ValidationResult("Tem que ser maior que 18 Anos"); ;
               
            }


            return ValidationResult.Success;

        }
    }
}
