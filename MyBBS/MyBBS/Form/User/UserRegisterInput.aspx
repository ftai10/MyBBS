<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegisterInput.aspx.cs" Inherits="MyBBS.Form.User.UserRegisterInput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    会員情報登録
     <div>
        <span>UserName</span>
        <input id="inpUserName" type="text" runat="server" />
        <asp:RegularExpressionValidator id="revUserName" 
            ControlToValidate="inpUserName"
            ValidationExpression="\w{1,16}"
            Display="Static"
            ErrorMessage="ユーザ名は1-16文字で入力してください"
            EnableClientScript="False" 
            runat="server"/>
    </div>

    <div>
        <span>LoginId</span>
        <input id="inpLoginId" type="text" runat="server" />
        <asp:RegularExpressionValidator id="revLoginId" 
            ControlToValidate="inpLoginId"
            ValidationExpression="\w{6,8}"
            Display="Static"
            ErrorMessage="ログインIDは6-8文字で入力してください"
            EnableClientScript="False" 
            runat="server"/>
    </div>
    <div>
        <span>Password</span>
        <input id="inpPassword" type="password" runat="server"/>
        <asp:RegularExpressionValidator id="revPassword" 
            ControlToValidate="inpPassword"
            ValidationExpression="^.*(?=.{6,8})(?=.*[A-z])(?=.*[\d])(?=.*[\W]).*$"
            Display="Static"
            ErrorMessage="パスワードは英数字と 記号含む6-8文字で入力してください"
            EnableClientScript="False" 
            runat="server"/>
    </div>
    <div>
        <asp:Button ID="btnRegister" runat="server" Text="登録する" OnClick="btnRegister_Click" />
    </div>
</asp:Content>
