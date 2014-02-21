<%@ Page Language="C#" MasterPageFile="~/Main.Master" Inherits="Language.WebUserInterface.Instructions" %>

<asp:Content ContentPlaceHolderID="content" runat="server">

    <h1>Instructions for contributing to the Orion's Belt Translation Project</h1>
    
    <h2>How to Apply</h2>
    
    To be able to contribute, you just need to register and then contact us to the manual@orionsbelt.eu email 
    with your target language. After that you'll be able to easilly update the translation tokens.
    <p />
    You may also contact us if you want to maintain a specific language.
    <p />
    If you help us, be sure that we'll reward you with orions for your efforts. :-)
    
    <h2>Where to Start?</h2>
    
    <p>We have two global projects to translate:</p>
    <ul>
        <li>Game - This includes the ingame text and <a href="http://manual.orionsbelt.eu">manual</a>, it's the biggest project</li>
        <li>Institutional - This includes the website at <a href="http://www.orionsbelt.eu">orionsbelt.eu</a></li>
    </ul>
    
    <h2>Editing Guidelines</h2>
    
    <ul>
        <li>
            If you spot on a translation something between brackets, you 
            can't translated it. For example: "This facility gathers [Energy]";
            [Energy] will be automatically replaced by the content of the
            "Energy" entry.
        </li>
        <li>
            You may find something like: "{0}" on the localizations. That means
            that a variable will be inserted on that location, you should keep
            those tokens on your translation at a suitable place. If you don't
            understand what's going to be replaced, contact us.
        </li>
        <li>
            Any questions, please contact us at manual@orionsbelt.eu
        </li>
    </ul>
    
    <h2>When will my updates be online?</h2>
    
    Every night we have a process that merges the content of this site with our original translation files. Only when we deploy the application
    will you work be online. If you have some urgency because of some critical fixes, contact us.

    <p>Thank you!</p>
    
</asp:Content>
