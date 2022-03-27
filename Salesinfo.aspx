<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Salesinfo.aspx.cs" Inherits="RAMCO_MAPPING1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">  
            <h2>YOUR SALES INFORMATION</h2>  
            <table class="table" id="maintable">  
                <thead>  
                    <tr>  
                        <th>ITEM NAME</th>  
                        <th>QUANTITY OF SALES(MT)</th>  
                        <th>DATES OF SALE</th>  
                    </tr>  
                </thead>  
                <tbody>  
                    <tr class="data-contact-person">  
                        <td>  
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Item Name"></asp:TextBox></td>  
                        <td>  
                            <asp:TextBox CssClass="form-control" ID="Txtname" runat="server" placeholder="Quantity"></asp:TextBox></td>  
                        <td>  
                             <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="enter in format DD/MM/YYYY"></asp:TextBox></td>  
                        <td>  
                            <asp:Button type="button" ID="btnreset" runat="server" CssClass="btn btn-primary btn-md pull-right btn-sm" OnClick="btnreset_Click" Text="RESET" ></asp:Button>  
                        </td>  
                    </tr>  
                </tbody>  
            </table>  
            <asp:Button type="button" ID="btnSubmit" runat="server" CssClass="btn btn-primary btn-md pull-right btn-sm" OnClick="btnSubmit_Click" Text="Submit" ></asp:Button>
        </div>   
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" style="margin-left: 84px; margin-top: 52px;" Width="729px" OnRowDeleting="GridView1_RowDeleting" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="ITEM_NAME" HeaderText="ITEM NAME" />
                <asp:BoundField DataField="QUANTITY_OF_SALES_(MT)" HeaderText="QUANTITY_OF_SALES_(MT)" />
                <asp:BoundField DataField="DATE" HeaderText="DATE OF SALES" />
                <asp:CommandField ButtonType="Button" ShowEditButton="True" >
                <ControlStyle BackColor="#33CC33" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                <ControlStyle BackColor="Red" />
                </asp:CommandField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
<asp:Button ID="Button1" runat="server" BackColor="#009900" OnClick="btnSubmit_Click2" Text="NEXT" Width="430px" style="margin-left: 254px" />
</asp:Content>
