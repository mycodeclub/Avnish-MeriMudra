<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BPRegistration.aspx.cs" Inherits="BPRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MMContentHolder" runat="Server">

    <!-- content start -->
    <script>
        window.scrollTo(0, document.querySelector("txtName").scrollHeight);
    </script>
    <div class="">
        <div class="container">
            <div class="row">
                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                    <div class="wrapper-content bg-white pinside40">
                        <div class="contact-form mb60">
                            <div class=" ">
                                <div class="offset-xl-12 col-xl-12 offset-lg-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                    <div class="mb60  section-title text-center  ">
                                        <!-- section title start-->
                                        <h1>Business Partner Registration</h1>
                                        <p>Reach out to us &amp; we will respond as soon as we can.</p>
                                    </div>
                                </div>

                                <form class="contact-us" runat="server">
                                    <div class="">
                                        <!-- Text input-->
                                        <div class="row">
                                            <div class="col-xl-4 col-lg-4 col-md-12 col-sm-12 col-12">
                                                <div class="form-group">
                                                    <label class="sr-only control-label" for="name">Full Name<span class=" "> </span></label>
                                                    <asp:TextBox ID="txtBPName" runat="server" required placeholder="Full Name" class="form-control input-md"></asp:TextBox>
                                                </div>
                                            </div>
                                            <!-- Text input-->
                                            <div class="col-xl-4 col-lg-4 col-md-12 col-sm-12 col-12">
                                                <div class="form-group">
                                                    <label class="sr-only control-label" for="email">Mobile<span class=" "> </span></label>
                                                    <asp:TextBox ID="txtBPNumber" runat="server" required placeholder="Mobile" Class="form-control input-md"></asp:TextBox>
                                                </div>
                                            </div>
                                            <!-- Text input-->
                                            <div class="col-xl-4 col-lg-4 col-md-12 col-sm-12 col-12">
                                                <div class="form-group">
                                                    <label class="sr-only control-label" for="phone">Email<span class=" "> </span></label>
                                                    <asp:TextBox ID="txtBPEmail" runat="server" required placeholder="Email" Class="form-control input-md"></asp:TextBox>
                                                </div>
                                            </div>
                                            <!-- Text input-->
                                            <div class="col-xl-4 col-lg-4 col-md-12 col-sm-12 col-12">
                                                <div class="form-group">
                                                    <label class="sr-only control-label" for="phone">PAN<span class=" "> </span></label>
                                                    <asp:TextBox ID="txtBPPAN" runat="server" required placeholder="PAN" Class="form-control input-md"></asp:TextBox>
                                                </div>
                                            </div>
                                            <!-- Text input-->
                                            <div class="col-xl-4 col-lg-4 col-md-12 col-sm-12 col-12">
                                                <div class="form-group">
                                                    <label class="sr-only control-label" for="phone">Aadhar<span class=" "> </span></label>
                                                    <asp:TextBox ID="txtBPAadhar" runat="server" required placeholder="Aadhar" Class="form-control input-md"></asp:TextBox>
                                                </div>
                                            </div>
                                            <!-- Text input-->
                                            <div class="col-xl-4 col-lg-4 col-md-12 col-sm-12 col-12">
                                                <div class="form-group">
                                                    <label class="sr-only control-label" for="phone">Company<span class=" "> </span></label>
                                                    <asp:TextBox ID="txtBPCompany" runat="server" required placeholder="Company" Class="form-control input-md"></asp:TextBox>
                                                </div>
                                            </div>
                                            <!-- Text input-->
                                            <div class="col-xl-4 col-lg-4 col-md-12 col-sm-12 col-12">
                                                <div class="form-group">
                                                    <label class="sr-only control-label" for="phone">City<span class=" "> </span></label>
                                                    <asp:TextBox ID="txtBPCity" runat="server" required placeholder="City" Class="form-control input-md"></asp:TextBox>
                                                </div>
                                            </div>
                                            <!-- Button -->
                                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                                <asp:Button ID="btnBPSubmit" Class="btn btn-default" OnClick="btnBPSubmit_Click" runat="server" Text="Register" />
                                                <asp:Label ID="lblMsg" ForeColor="Orange" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                        <!-- /.section title start-->
                    </div>
                    <div class="section-space80 bg-white">
                        <div class="container">
                            <div class="row">
                                <div class="offset-xl-2 col-xl-8 offset-lg-2 col-lg-8 offset-md-2 col-md-8  col-sm-12 col-12">
                                    <div class="mb60 text-center section-title">
                                        <!-- section title-->
                                        <h1>We are Here to Help You</h1>
                                        <p>Our mission is to deliver reliable, latest news and opinions.</p>
                                    </div>
                                    <!-- /.section title-->
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-12 col-12">
                                    <div class="bg-white bg-boxshadow pinside40 outline text-center mb30">
                                        <div class="mb40"><i class="icon-calendar-3 icon-2x icon-default"></i></div>
                                        <h2 class="capital-title">Apply For Loan</h2>
                                        <p>Looking to buy a car or home loan? then apply for loan now.</p>
                                        <a href="#" class="btn-link">Get Appointment</a>
                                    </div>
                                </div>
                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-12 col-12">
                                    <div class="bg-white bg-boxshadow pinside40 outline text-center mb30">
                                        <div class="mb40"><i class="icon-phone-call icon-2x icon-default"></i></div>
                                        <h2 class="capital-title">Call us at </h2>
                                        <h1 class="text-big">+91 83 18 17 13 83</h1>
                                        <p>info@merimudra.com</p>
                                        <a href="#" class="btn-link">Contact us</a>
                                    </div>
                                </div>
                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-12 col-12">
                                    <div class="bg-white bg-boxshadow pinside40 outline text-center mb30">
                                        <div class="mb40"><i class="icon-users icon-2x icon-default"></i></div>
                                        <h2 class="capital-title">Talk to Advisor</h2>
                                        <p>Need to loan advise? Talk to our Loan advisors.</p>
                                        <a href="#" class="btn-link">Meet The Advisor</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.content end -->

</asp:Content>

