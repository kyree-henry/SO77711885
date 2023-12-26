using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace Library
{
    public partial class AuthInput
    {
        // Do you need this?
        //[Parameter] public string Id { get; set; }
        [Parameter] public string? LabelText { get; set; }
        [Parameter] public string ColSize { get; set; } = "col-12";
        // Do you need this?
        //[Parameter] public string FieldName { get; set; }
        [Parameter] public string PlaceHolder { get; set; } = "Enter a value";
        [Parameter] public bool IsRequired { get; set; } = false;
        [Parameter] public TextFieldType TextFieldType { get; set; } = TextFieldType.Text;

        // Why include number - InputBase<int> if it's a integer
        private string _type => TextFieldType == TextFieldType.Text ? "text" :
                                TextFieldType == TextFieldType.Number ? "number" :
                                TextFieldType == TextFieldType.Password ? "password" :
                                TextFieldType == TextFieldType.EmailAddress ? "email" :
                                "text";

        private void SetValue(ChangeEventArgs e)
        {
            this.CurrentValueAsString = e.Value?.ToString() ?? null;
        }

        protected override bool TryParseValueFromString(string? value, out string? result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}