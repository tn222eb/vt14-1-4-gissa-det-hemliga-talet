<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GissaDetHemligaTalet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet</title>
    <link href="~/Content/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Gissa det hemliga talet</h1>
            <!-- Textbox och validering -->
            <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Fel inträffade. Korrigera felet och gör ett nytt försök" CssClass="field-validation-error" />
            <span id="TextBoxLabel">Ange ett tal mellan 1 och 100:</span>
            <br />
            <asp:TextBox ID="ValueTextBox" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator" Text="*" CssClass="field-validation-error" runat="server" ErrorMessage="Ange ett tal mellan 1 och 100" MaximumValue="100" MinimumValue="1" Display="Dynamic" ControlToValidate="ValueTextBox" Type="Integer"></asp:RangeValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator" Text="*" CssClass="field-validation-error" runat="server" ErrorMessage="Ett tal måste anges" ControlToValidate="ValueTextBox" Display="Dynamic"></asp:RequiredFieldValidator>

            <asp:Button ID="SendButton" runat="server" Text="Skicka gissning" OnClick="SendButton_Click" />
            <br />
            <!-- Presentation av användarens gissningar-->
            <asp:PlaceHolder ID="GuessesPlaceHolder" runat="server" Visible="false">
                <asp:Label ID="Guesses" runat="server" Text=""></asp:Label>
            </asp:PlaceHolder>

            <!-- Presentation av resultat-->
            <br />
            <asp:PlaceHolder ID="ResultPlaceHolder" runat="server" Visible="false">
                <asp:Label ID="Result" runat="server" Text=""></asp:Label>
            </asp:PlaceHolder>
        </div>
        <asp:Button ID="RandomNumberButton" runat="server" Text="Slumpa nytt hemligt tal" Visible="false" OnClick="RandomNumberButton_Click" />
         <script type="text/javascript">
             var textBox = document.getElementById("ValueTextBox");
             textBox.focus();
             textBox.select();
      </script>
    </form>
</body>
</html>
