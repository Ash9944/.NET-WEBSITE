<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="RAMCO_MAPPING1.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">  
            <h2>DEALER'S NEAR YOU</h2> 
      </div>

        <p id="message"></p>
        <asp:HiddenField ID="hdnLocation" runat="server" />
        <asp:Button ID="btnSubmit" runat="server" Text="Get 5 Nearest Places" OnClick="btnSubmit_Click" BackColor="#33CC33" CssClass="btn-info active" style="margin-left: 370px" Width="476px" />


        <asp:GridView ID="GridView1" runat="server" CellPadding="3" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" Width="1154px" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
        <div id="map" style="width: 600px; height: 400px;"></div>

    <script src="http://maps.googleapis.com/maps/api/js?sensor=false" type="text/javascript"></script>
    <script type="text/javascript">
        $('[id*=btnSubmit]').prop('disabled', true);
        var currentLatLng;
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition, showError);
        }
        else { $("#message").html("Geolocation is not supported by this browser."); }
        function showPosition(position) {
            currentLatLng = position.coords;

            var latlon = "Latitude" + currentLatLng.latitude + "," + "Longitude" + currentLatLng.longitude;
            $("#message").html(latlon);
            $("[id*=hdnLocation]").val(currentLatLng.longitude + " " + currentLatLng.latitude);
            $('[id*=btnSubmit]').prop('disabled', false);
        }
        function showError(error) {
            if (error.code == 1) {
                $("#message").html("User denied the request for Geolocation.");
            }
            else if (error.code == 2) {
                $("#message").html("Location information is unavailable.");
            }
            else if (error.code == 3) {
                $("#message").html("The request to get user location timed out.");
            }
            else {
                $("#message").html("An unknown error occurred.");
            }
        }
        //Map related code
        var map2, infoWindow;
        if (typeof points !== "undefined") {
            var mapOptions = {
                center: new google.maps.LatLng(points[0].Latitude, points[0].Longitude),
                zoom: 9,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            infoWindow = new google.maps.InfoWindow();
            map2 = new google.maps.Map(document.getElementById("map"), mapOptions);
            //marker for current location
            var marker = new google.maps.Marker({
                position: new google.maps.LatLng(currentLoc.Latitude, currentLoc.Longitude),
                map: map2,
                icon: 'https://maps.google.com/mapfiles/kml/shapes/schools_maps.png'
            });
            //marker for nearest places
            for (i = 0; i < points.length; i++) {
                var data = points[i]
                var myLatlng = new google.maps.LatLng(data.Latitude, data.Longitude);
                var marker2 = new google.maps.Marker({
                    position: myLatlng,
                    map: map2,
                    title: data.Name
                });
                (function (marker2, data) {
                    google.maps.event.addListener(marker2, "click", function (e) {
                        infoWindow.setContent(data.Name);
                        infoWindow.open(map2, marker2);
                    });
                })(marker2, data);
            }
        }
    </script>
</asp:Content>
