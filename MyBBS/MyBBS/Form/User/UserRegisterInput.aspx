<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegisterInput.aspx.cs" Inherits="MyBBS.Form.User.UserRegisterInput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Literal id="ltPageTitle" runat="server" Text="会員情報"/>
     <div>
        <span>UserName</span>
        <input id="inpUserName" type="text" runat="server" />
        <asp:RegularExpressionValidator id="revUserName" 
            ControlToValidate="inpUserName"
            ValidationGroup="requiredGroup"
            ValidationExpression="\w{1,16}"
            Display="Static"
            ErrorMessage="ユーザ名は1-16文字で入力してください"
            EnableClientScript="False" 
            runat="server"/>

         <asp:RequiredFieldValidator id="reqUserName"
             ControlToValidate="inpUserName"
             ValidationGroup="requiredGroup"
             Display="Static"
             EnableClientScript="false"
             runat="server"
             ErrorMessage="ユーザ名を入力してくだい。">
         </asp:RequiredFieldValidator>
    </div>

    <div>
        <span>LoginId</span>
        <input id="inpLoginId" type="text" runat="server" />
        <asp:RegularExpressionValidator id="revLoginId" 
            ControlToValidate="inpLoginId"
            ValidationGroup="requiredGroup"
            ValidationExpression="\w{6,8}"
            Display="Static"
            ErrorMessage="ログインIDは6-8文字で入力してください"
            EnableClientScript="False" 
            runat="server"/>

         <asp:RequiredFieldValidator id="reqLoginId"
             ControlToValidate="inpLoginId"
             ValidationGroup="requiredGroup"
             Display="Static"
             EnableClientScript="false"
             runat="server"
             ErrorMessage="ログインIDを入力してくだい。">
         </asp:RequiredFieldValidator>

    </div>
    <div>
        <span>Password</span>
        <input id="inpPassword" type="password" runat="server"/>
        <asp:RegularExpressionValidator id="revPassword" 
            ControlToValidate="inpPassword"
            ValidationGroup="requiredGroup"
            ValidationExpression="^.*(?=.{6,8})(?=.*[A-z])(?=.*[\d])(?=.*[\W]).*$"
            Display="Static"
            ErrorMessage="パスワードは英数字と 記号含む6-8文字で入力してください"
            EnableClientScript="False" 
            runat="server"/>

         <asp:RequiredFieldValidator id="reqPassword"
             ControlToValidate="inpPassword"
             ValidationGroup="requiredGroup"
             Display="Static"
             EnableClientScript="false"
             runat="server"
             ErrorMessage="パスワードを入力してくだい。">
         </asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Button ID="btnConfirm" runat="server" Text="確認する" OnClick="btnConfirm_Click" />
    </div>
</asp:Content>
