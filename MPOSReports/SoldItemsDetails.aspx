﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SoldItemsDetails.aspx.cs" Inherits="MPOSReports.WebForms.SoldItemsDetails" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-3.3.1.js"></script>
    <script src="../../Assets/js/select2.full.min.js"></script>
    <link href="../../Assets/css/select2.min.css" rel="stylesheet" />

    <script>
        $(document).ready(function () {
            $("#<%=ddlFromItem.ClientID%>").select2({
                placeholder: "Select Item",
            });
        });

        $(document).ready(function () {
            $("#<%=ddltoItem.ClientID%>").select2({
                placeholder: "Select Item",
            });
        });
    </script>

    <style>
        .hover {
            background-color: #f2dede;
        }

        html {
            overflow: scroll;
        }

        ::-webkit-scrollbar {
            width: 0px;
            background: transparent;
        }

        .element::-webkit-scrollbar {
            width: 0 !important
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Sold Items Details</h2>

    <div class="panel panel-danger" style="padding-top: 0px;">
        <div class="panel-heading">
            <p><strong>SELECTION PANEL</strong></p>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <div class="col-md-3" style="padding-top: 5px;">
                        <label id="Label2" runat="server">Factory  </label>
                    </div>
                    <div class="col-md-1">
                        <asp:DropDownList ID="ddlFactory" AutoPostBack="true" runat="server" CssClass="form-control" Width="150px" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlFactory_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="col-md-3" style="padding-top: 5px;">
                        <label id="Label5" runat="server">From Item:  </label>
                    </div>
                    <div class="col-md-1">
                        <asp:DropDownList ID="ddlFromItem" AutoPostBack="true" runat="server" CssClass="form-control" Width="150px" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlFromItem_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="col-md-3" style="padding-top: 5px;">
                        <label id="Label1" runat="server">To Item:  </label>
                    </div>
                    <div class="col-md-1">
                        <asp:DropDownList ID="ddltoItem" runat="server" CssClass="form-control" Width="150px" AppendDataBoundItems="true" OnDataBound="ddltoItem_DataBound">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <div class="col-md-3">
                        <label id="Label3" runat="server">From Date</label>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" style="width: 150px; height: 40px;" runat="server" disabled="disabled" id="txtFromDate" />
                    </div>
                    <div class="col-md-2">
                        <asp:LinkButton ID="lbFromDate" runat="server" OnClick="lbFromDate_Click">
                                    <span class="glyphicon glyphicon-calendar" style="color:#772953; font-size:x-large;"></span>
                        </asp:LinkButton>
                        <asp:Calendar ID="calFromDate" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Georgia" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="250px" runat="server" OnDayRender="calFromDate_DayRender" OnSelectionChanged="calFromDate_SelectionChanged">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#772953" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#772953" />
                            <TodayDayStyle BackColor="Gray" />
                        </asp:Calendar>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="col-md-3">
                        <label id="Label4" runat="server">To Date</label>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" style="width: 150px; height: 40px;" runat="server" disabled="disabled" id="txtToDate" />
                    </div>
                    <div class="col-md-2">
                        <asp:LinkButton ID="lbToDate" runat="server" OnClick="lbToDate_Click">
                                    <span class="glyphicon glyphicon-calendar" style="color:#772953; font-size:x-large;"></span>
                        </asp:LinkButton>
                        <asp:Calendar ID="calToDate" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Georgia" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="250px" runat="server" OnDayRender="calToDate_DayRender" OnSelectionChanged="calToDate_SelectionChanged">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#772953" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#772953" />
                            <TodayDayStyle BackColor="Gray" />
                        </asp:Calendar>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="col-md-3">
                    </div>
                    <div class="col-md-4">
                        <asp:Button ID="btnDetails" runat="server" Text="Generate" CssClass="btn btn-default" Style="background-color: gainsboro; color: black; border-radius: 0 10px; font-weight: bold" Width="150px" OnClick="btnDetails_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row" style="padding-top: 20px; padding-bottom: 10px; width: 103%; overflow: scroll;">

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" SizeToReportContent="true" Height="37px" Width="457px"></rsweb:ReportViewer>
    </div>
</asp:Content>