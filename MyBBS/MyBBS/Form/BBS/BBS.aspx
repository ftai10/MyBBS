<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BBS.aspx.cs" Inherits="MyBBS.Form.BBS.BBS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     BBS TOP
    <!--  新規投稿フォーム -->
    <div>
        <div>
            <asp:Literal ID="ltName" runat="server"></asp:Literal> 
        </div>

        <div>
            <asp:TextBox ID="tbTitle" runat="server" placeholder="タイトル" ></asp:TextBox> 
        </div>
        <div>
            <asp:TextBox ID="tbContent" runat="server"　placeholder="本文を記載" ></asp:TextBox>
        </div>
        <div>
            <asp:Button  ID="btPost" runat="server" Text="投稿する" OnClick="btPost_Click"/>
        </div>
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
