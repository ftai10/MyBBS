<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BBSTop.aspx.cs" Inherits="MyBBS.Form.BBS.BBSTop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div>
          <span>ログインID</span>
          <input id="inpLoginId" type="text" />
     </div>
     <div>
          <span>パスワード</span>
          <input id="inpPassword" type="password" />
     </div>
     <div>
         <asp:Button ID="btnLogin" runat="server" Text="ログイン" OnClick="btnLogin_Click" />
     </div>
     <div>
         <asp:Literal ID="lerrorMessage" runat="server"></asp:Literal>
     </div>
</asp:Content>
