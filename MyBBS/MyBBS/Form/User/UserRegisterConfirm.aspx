<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegisterConfirm.aspx.cs" Inherits="MyBBS.Form.User.UserRegisterConfirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   　確認画面
    <div>
        <span>UserName</span>
        <asp:Literal ID="ltUserName" runat="server"></asp:Literal>
    </div>
    <div>
        <span>LoginId</span>
        <asp:Literal ID="ltLoginId" runat="server"></asp:Literal>
    </div>

    <div>
        <asp:Button ID="btnRegister" runat="server" Text="登録する" OnClick="btnRegister_Click" />
    </div>


</asp:Content>
