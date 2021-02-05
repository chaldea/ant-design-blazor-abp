using AntDesign.Abp.Pro.Blazor.Models;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Abp.Pro.Blazor.Pages.Form
{
    public partial class Step2
    {
        private readonly StepFormModel _model = new StepFormModel();

        [CascadingParameter] public StepForm StepForm { get; set; }

        public void OnValidateForm()
        {
            StepForm.Next();
        }

        public void Preview()
        {
            StepForm.Prev();
        }
    }
}