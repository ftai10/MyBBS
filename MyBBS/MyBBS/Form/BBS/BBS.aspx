<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BBS.aspx.cs" Inherits="MyBBS.Form.BBS.BBS" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     BBS TOP
    <div class="container">
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li><a runat="server" href="~/Form/User/UserRegisterInput.aspx">会員情報編集</a></li>
                <li><asp:Button ID="btnLogoff" runat="server" Text="ログオフ" OnClick="btnLogoff_Click" /><li>
            </ul>
        </div>
    </div>

    <!--  投稿フォーム -->
    <div style="width:600px">
        <div>
            <div>投稿者:</div>
            <span>
             <%= HttpUtility.HtmlEncode(Session[MyBBS.Util.BBSConst.SESSION_NAME_USER_NAME].ToString()) %>
            </span>
        </div>

        <div>
            <div>タイトル:</div>

            <asp:TextBox ID="tbTitle" runat="server" ></asp:TextBox>
        </div>
        <div>
            <div>本文:</div>
            <asp:TextBox ID="tbPostText" runat="server"  TextMode="MultiLine" Height="100px" Width="600px" ></asp:TextBox>
        </div>
        <div style="text-align:right">
            <asp:Button  ID="btPost" runat="server" Text="投稿する" OnClick="btPost_Click"/> &nbsp;
            <asp:Button  ID="btEdit" runat="server" Visible="false" Text="編集する" OnClick="btPost_Click"/> &nbsp;
            <asp:Button  ID="btDel" runat="server" Visible="false"  Text="削除する" OnClick="btDel_Click"/>
        </div>
        
        <!-- 更新、削除、返信、ページングの際に必要な隠しパラメータ -->
        <asp:HiddenField ID="hdnTreadId" runat="server" Value="0" /> 
        <asp:HiddenField ID="hdnOrigenTreadId" runat="server" Value="0" /> 
        <asp:HiddenField ID="hdnIsDeleteFlg" runat="server" Value="0" />
        <asp:HiddenField ID="hdnPageNo" runat="server" Value="1" />
        
    </div>
    <div style="width:600px">
        <div style="float:left">
           <asp:LinkButton runat="server" ID="linkPreviousThread" Text="<<" OnClick="linkPreviousThread_Click" />
        </div>
        <div style="float:right">
           <asp:LinkButton runat="server" ID="linkNextThread" Text=">>" OnClick="linkNextThread_Click" />
        </div>
    </div>

    <!-- 掲示板 -->
    <div style="width:600px">
        <asp:Repeater ID="rptBBS" runat="server" OnItemDataBound="rptBBS_ItemDataBound" OnItemCommand="rptBBS_ItemCommand">
        <ItemTemplate>
            <div id="threadArea" runat="server">
                <div style="font-size:18px; font-weight:400;">
                    <span>投稿者</span>
                    <span><%# HttpUtility.HtmlEncode(Eval("UserName")) %><span>
                    <span style="float:right">投稿日:<%# HttpUtility.HtmlEncode(Eval("CreateDate")) %></span>
                </div>

                <div style="font-size:18px; font-weight:600;">
                    <span>タイトル</span>
                    <asp:Literal runat="server" ID="lttitle" text='<%# HttpUtility.HtmlEncode(Eval("Title")) %>'/>
                </div>

                <pre class="TextArea"><%# HttpUtility.HtmlEncode(Eval("PostText")) %>
                </pre>

                <div style="text-align:right">
                    <asp:LinkButton id="linkEdit" runat="server" CommandName="Edit">編集</asp:LinkButton>
                    <asp:LinkButton id="linkRes" runat="server" CommandName="Res">返信</asp:LinkButton>
                </div>
            </div>

            <asp:HiddenField id="hdnPostText" runat="server" Value='<%# HttpUtility.HtmlEncode(Eval("PostText")) %>'/>
            <asp:HiddenField id="hdnTreadId" runat="server" Value='<%# Eval("ThreadId") %>'/>
        </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
