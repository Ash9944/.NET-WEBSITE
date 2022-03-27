<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RAMCO_MAPPING1._Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                           <h4>SUBDEALER REGISTRATION</h4>
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
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Txtname" runat="server" placeholder="Full Name"></asp:TextBox>
                           </div>
                     </div>
                     <div class="col-md-6">
                        <label>GST number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextGST" runat="server" placeholder="GST number"></asp:TextBox>
                             </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Txtnumber" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                        </div>

                     </div>
                     <div class="col-md-6">
                        <label>Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Txtmail" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>State</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                              <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                              <asp:ListItem Text="Assam" Value="Assam" />
                              <asp:ListItem Text="Bihar" Value="Bihar" />
                              <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Goa" Value="Goa" />
                              <asp:ListItem Text="Gujarat" Value="Gujarat" />
                              <asp:ListItem Text="Haryana" Value="Haryana" />
                              <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                              <asp:ListItem Text="Jammu and Kashmir" Value="Jammu and Kashmir" />
                              <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                              <asp:ListItem Text="Karnataka" Value="Karnataka" />
                              <asp:ListItem Text="Kerala" Value="Kerala" />
                              <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                              <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                              <asp:ListItem Text="Manipur" Value="Manipur" />
                              <asp:ListItem Text="Meghalaya" Value="Meghalaya" />
                              <asp:ListItem Text="Mizoram" Value="Mizoram" />
                              <asp:ListItem Text="Nagaland" Value="Nagaland" />
                              <asp:ListItem Text="Odisha" Value="Odisha" />
                              <asp:ListItem Text="Punjab" Value="Punjab" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Sikkim" Value="Sikkim" />
                              <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                              <asp:ListItem Text="Telangana" Value="Telangana" />
                              <asp:ListItem Text="Tripura" Value="Tripura" />
                              <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                              <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                              <asp:ListItem Text="West Bengal" Value="West Bengal" />
                           </asp:DropDownList>
                             </div>
                     </div>
                     <div class="col-md-4">
                        <label>City</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="Txtcity" runat="server" placeholder="City"></asp:TextBox>
                            </div>
                     </div>
                     <div class="col-md-4">
                        <label>Pincode</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TxtPIN" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>
                          </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Txtaddress" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            </div>
                  </div>
                  <div class="row">
                     <div class="col">
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Bank Name</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TxtBANK" runat="server" placeholder="BANK'S NAME"></asp:TextBox>
            
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Pan number</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TxtPAN" runat="server" placeholder="PAN"></asp:TextBox>
                             
                    
                        </div>
                     </div>
                  </div>
                   <div class="col-md-6">
                        <label>Hint Question</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="Hint_q" runat="server" placeholder="Type your secret question"></asp:TextBox>
                            
                           
                        </div>
                     </div>
                   <div class="col-md-6">
                        <label>Hint Answer</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="Hint_a" runat="server" placeholder="Type your Answer" ></asp:TextBox>
                            
                        </div>
                     </div>
                   <div class="col-md-6">
                        <label>File Upload</label>
                        <div class="form-group">
                                <asp:FileUpload ID="FileUpload1" runat="server" meta:resourcekey="FileUpload1Resource1" /> 
                        </div>
                     </div>

                  <div class="row">
                     <div class="col">
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" />
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
