<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BBSTop.aspx.cs" Inherits="MyBBS.Form.BBS.BBSTop" %>
<%@ MasterType VirtualPath ="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li><a runat="server" href="~/Form/User/UserRegisterInput.aspx">会員登録</a></li>
            </ul>
        </div>
    </div>

     <div>
          <span>ログインID</span>
          <input id="inpLoginId" type="text" runat="server" />
     </div>
     <div>
          <span>パスワード</span>
          <input id="inpPassword" type="password" runat="server" />
     </div>
     <div>
         <asp:Button ID="btnLogin" runat="server" Text="ログイン" OnClick="btnLogin_Click" />
     </div>
     <div>
         <asp:Literal ID="lerrorMessage" runat="server"></asp:Literal>
     </div>
</asp:Content>
