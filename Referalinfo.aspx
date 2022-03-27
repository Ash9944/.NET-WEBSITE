<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Referalinfo.aspx.cs" Inherits="RAMCO_MAPPING1.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" align="center">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/generaluser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>REFERAL INFORMATION</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Name of Influencer</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Txtname" runat="server" placeholder="Full Name"></asp:TextBox>
                          </div> 
                     </div>
                     <div class="col-md-4">
                        <label>Influencer Type</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Txttype" runat="server" placeholder="type of influencer"></asp:TextBox>
                            
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Contact No of Influencer</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Txtnumber" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                         
                          </div>
                        </div>

                  <div class="row">
                     <div class="col-md-7">
                        <label>Address of Influencer</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Txtaddress" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                      </div>
                  </div>
           

                  <div class="row">
                     <div class="col">
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                        </div>
                     </div>
                  </div>
                  
               </div>
      </div>
   </div>

    

    </div>
</div>
    </div>
</asp:Content>
