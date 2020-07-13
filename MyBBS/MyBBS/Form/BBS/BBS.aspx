<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BBS.aspx.cs" Inherits="MyBBS.Form.BBS.BBS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     BBS TOP
    <!--  新規投稿フォーム -->
    <div>
        <asp:TextBox ID="txTitle" runat="server" placeholder="タイトル" ></asp:TextBox>
        <asp:TextBox ID="txContent" runat="server"　placeholder="本文を記載" ></asp:TextBox>
    </div>

    <!-- 掲示板 -->
    <div>
        <asp:Repeater ID="rptBBS" runat="server" OnItemDataBound="rptBBS_ItemDataBound">
        <ItemTemplate>
            <asp:Literal ID="ltTitle"  runat="server"></asp:Literal>
            <asp:LinkButton id="editBtn" runat="server" OnClick="editBtn_Click">編集</asp:LinkButton>
        </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
