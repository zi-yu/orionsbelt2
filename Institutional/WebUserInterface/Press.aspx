<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Press.aspx.cs" Inherits="WebUserInterface.Press" MasterPageFile="~/ContentPageMaster.Master" %>

<asp:Content ContentPlaceHolderID="contentPageContent" runat="server">

    <Institutional:Label ID="Label2" Key="PressKit" runat="server" />

    <div style="float:left;width:400px;padding:10px;">
        <h2><Institutional:Label Key="MediaArticles" runat="server" /></h2>
        
        <Institutional:MediaArticleList ID="mediaArticles" runat="server">
            <ul class='mediaArticles'>
                <Institutional:MediaArticleItem runat="server">
                    <li>
                        <InstitutionalUI:MediaArticleFlag runat="server" />
                        <div class='title'><InstitutionalUI:MediaArticleLink runat="server" /></div>
                        <div class='excerpt'>"<Institutional:MediaArticleExceprt runat="server" />"</div>
                    </li>
                </Institutional:MediaArticleItem>
            </ul>
        </Institutional:MediaArticleList>
    </div>
    
    <div style="float:left;width:400px;margin-left:25px;padding:10px;">
        <h2><Institutional:Label ID="Label1" Key="Testimonials" runat="server" /></h2>
        
        <Institutional:TestimonialList ID="testimonials" runat="server">
            <ul class='testimonials'>
                <Institutional:TestimonialItem ID="TestimonialItem1" runat="server">
                    <li>
                        <div class="content">
                            "<Institutional:TestimonialContent ID="TestimonialItem2" runat="server" />"
                        </div>
                        <div class="author">
                            <Institutional:TestimonialAuthor ID="TestimonialContent1" runat="server" />
                        </div>
                    </li>
                </Institutional:TestimonialItem>
            </ul>
        </Institutional:TestimonialList>
    </div>
    
    <div class="clear"></div>
    
</asp:Content>
