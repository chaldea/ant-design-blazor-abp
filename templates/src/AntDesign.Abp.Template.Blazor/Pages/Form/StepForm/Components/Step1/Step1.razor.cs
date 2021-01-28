using AntDesign.Abp.Template.Blazor.Models;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Abp.Template.Blazor.Pages.Form
{
    public partial class Step1
    {
        private readonly StepFormModel _model = new StepFormModel();

        [CascadingParameter] public StepForm StepForm { get; set; }

        public void OnValidateForm()
        {
            StepForm.Next();
        }
    }
}