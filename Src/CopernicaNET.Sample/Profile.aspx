<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="Arlanet.CopernicaNET.Sample.Profile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Add Profile (Client)</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ProfileID" CssClass="col-md-2 control-label">ID</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="ProfileID" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileID"
                    CssClass="text-danger" ErrorMessage="The ID field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ProfileName" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="ProfileName" TextMode="SingleLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileName"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ProfileEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="ProfileEmail" TextMode="Email" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileEmail"
                    CssClass="text-danger" ErrorMessage="The Email field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="Add_Profile" Text="Add" CssClass="btn btn-default" />
                <asp:Button runat="server" OnClick="Update_Profile" Text="Update" CssClass="btn btn-default" />
                <asp:Button runat="server" OnClick="Delete_Profile" Text="Delete" CssClass="btn btn-default" />
            </div> 
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Label ID="StatusLabel" runat="server"></asp:Label>
            </div> 
        </div>
    </div>
</asp:Content>