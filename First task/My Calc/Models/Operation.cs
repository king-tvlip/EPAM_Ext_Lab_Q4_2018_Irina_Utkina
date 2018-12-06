using My_Calc.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace My_Calc.Models
{
    public enum Operation
    {
        [Display(Name = "Add", ResourceType = typeof(CalcResources))]
        Add,
        [Display(Name = "Residual", ResourceType = typeof(CalcResources))]
        Residual,
        [Display(Name = "Multiplication", ResourceType = typeof(CalcResources))]
        Multiplication,
        [Display(Name = "NoOrdinaryOperation", ResourceType = typeof(CalcResources))]
        NoOrdinaryOperation,
        [Display(Name = "Division", ResourceType = typeof(CalcResources))]
        Division
    }
}