<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SubProfile.aspx.cs" Inherits="Arlanet.CopernicaNET.Sample.SubProfile" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Add SubProfile (Product)</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
            <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ProfileID" CssClass="col-md-2 control-label">Profile ID</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="ProfileID" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileID"
                    CssClass="text-danger" ErrorMessage="The ID field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="SubProfileName" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="SubProfileName" TextMode="SingleLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="SubProfileName"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Price" CssClass="col-md-2 control-label">Price</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="Price" TextMode="Number" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Price"
                    CssClass="text-danger" ErrorMessage="The Email field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="Add_SubProfile" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Label ID="StatusLabel" runat="server"></asp:Label>
                </div> 
            </div>
    </div>
</asp:Content>