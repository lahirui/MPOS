<%@ Page Title="MPOS Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MPOSReports._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <%--  <form id="form1" runat="server">--%>
        <div class="container container-fluid" style="margin-left:-160px">
            <div class="row col-sm-offset-1 col-md-offset-1 col-lg-offset-1" style="padding-top:20px;">
                <div class="col-sm-2 col-md-2 col-lg-2 ">
                    <div class="list-group" style="border-color: #9E1030; color: whitesmoke">
                        <div class="list-group-item h4" style="font-family: Georgia; font-weight: 500; color: whitesmoke; background-color: #9E1030; border-width: 3px; border-color: #9E1030;"><span class="fas fa-dollar-sign"></span>  Finance Reports</div>

                        <a href="#")" class="list-group-item" style="border-top-width: 1px; border-bottom-width: 1px; border-right-color: #9E1030; border-right-width: 3px; border-left-color: #9E1030; border-left-width: 3px;">
                            <h6 class="list-group-item-heading" style="color: #9E1030;">Purchase Detailes</h6>
                        </a>
                        <a href="#")" class="list-group-item" style="border-top-width: 1px; border-bottom-width: 3px;border-bottom-color: #9E1030; border-right-color: #9E1030; border-right-width: 3px; border-left-color: #9E1030; border-left-width: 3px;">
                            <h6 class="list-group-item-heading" style="color: #9E1030;"> Purchase Summary</h6>
                        </a>
                       
                    </div>
                </div>

                <div class="col-sm-2 col-md-2 col-lg-2 ">
                    <div class="list-group" style="border-color: #9E1030; color: whitesmoke">
                        <div class="list-group-item h4" style="font-family: Georgia; font-weight: 500; color: whitesmoke; background-color: #9E1030; border-width: 3px; border-color: #9E1030;"><span class="fas fa-coffee"></span>  Canteen Reports</div>

                        
                        <a href="#" class="list-group-item" style="border-top-width: 1px; border-bottom-color: #9E1030;  border-right-color: #9E1030; border-right-width: 3px; border-left-color: #9E1030; border-left-width: 3px;">
                            <h6 class="list-group-item-heading" style="color: #9E1030;"> Sold Item Details</h6>
                        </a>
                        <a href="#" class="list-group-item" style="border-top-width: 1px; border-bottom-color: #9E1030; border-bottom-width: 3px; border-right-color: #9E1030; border-right-width: 3px; border-left-color: #9E1030; border-left-width: 3px;">
                            <h6 class="list-group-item-heading" style="color: #9E1030;"> Item Transaction Summary</h6>
                        </a>
                    </div>
                </div>
            </div>
        </div>
<%--</form>--%>
</asp:Content>
