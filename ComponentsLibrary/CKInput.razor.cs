using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ComponentsLibrary
{
    public partial class CKInput : InputText
    {
        [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();
        [Parameter] public bool ShowError { get; set; } = false;
        [Parameter] public string LabelText { get; set; }
        [Parameter] public string ColSize { get; set; }
        [Parameter] public string Description { get; set; }
        [Parameter] public string PlaceHolder { get; set; }
        [Parameter] public string SuccessMessage { get; set; }
        [Parameter] public string AdornmentIcon { get; set; }
        [Parameter] public bool IsRequired { get; set; } = false;
        [Parameter] public EventCallback<string> OnAdornmentClick { get; set; }
        [Parameter] public Alignment AlignAdornment { get; set; } = Alignment.Right;
        [Parameter] public TextFieldType TextFieldType { get; set; } = TextFieldType.Text;

        private string _type => TextFieldType == TextFieldType.Text ? "text" :
                        TextFieldType == TextFieldType.Password ? "password" :
                        TextFieldType == TextFieldType.EmailAddress ? "email" :
                        "text";

        private string _inputClasses => new CssBuilder()
                                       .AddClass("form-control")
                                       .AddClass(CssClass, !string.IsNullOrEmpty(CssClass))
                                       .Build();

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }

        protected override Task OnParametersSetAsync()
        {
            try
            {
                IEnumerable<DisplayAttribute> displayAttribute = this.FieldIdentifier.Model.GetType()
                                       .GetProperty(this.FieldIdentifier.FieldName)
                                       .GetCustomAttributes<DisplayAttribute>();

                if (displayAttribute is not null)
                {
                    string displayName = displayAttribute.FirstOrDefault()?.Name;
                    if (!string.IsNullOrEmpty(displayName) && string.IsNullOrEmpty(LabelText))
                    {
                        LabelText = displayName;
                    }

                    string placeHolder = displayAttribute.FirstOrDefault()?.Prompt;
                    if (!string.IsNullOrEmpty(placeHolder) && string.IsNullOrEmpty(PlaceHolder))
                    {
                        PlaceHolder = placeHolder;
                    }

                    string description = displayAttribute.FirstOrDefault()?.Description;
                    if (!string.IsNullOrEmpty(description) && string.IsNullOrEmpty(Description))
                    {
                        Description = description;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return base.OnParametersSetAsync();
        }

    }
}