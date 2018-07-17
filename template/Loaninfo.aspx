﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Loaninfo.aspx.cs" Inherits="Loaninfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MMContentHolder" runat="Server">

    <!-- content start -->
    <div class="container">
        <div class="row">
            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                <div class="wrapper-content bg-white pinside40">
                    <div class="product-tabs">
                        <div class="row">
                            <!-- Nav tabs -->
                            <div class="col-xl-3 col-lg-3 col-md-3 col-sm-12 col-12 nopadding">

                                <ul class="nav nav-tabs flex-column" id="myTab" role="tablist">

                                    <li class="nav-item">
                                        <a class="nav-link active" id="tab-1" data-toggle="tab" href="#overview" role="tab" aria-controls="overview" aria-selected="true"><i class="fa fa-search-plus"></i>Overview</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="tab-2" data-toggle="tab" href="#features" role="tab" aria-controls="features" aria-selected="false"><i class="fa fa-star"></i>Features</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="tab-3" data-toggle="tab" href="#eligibility" role="tab" aria-controls="eligibility" aria-selected="false"><i class="fa fa-check-square-o"></i>eligibility</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="tab-4" data-toggle="tab" href="#documentation" role="tab" aria-controls=" documentation" aria-selected="false"><i class="fa fa-file-text-o"></i>Documentation </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="tab-4" data-toggle="tab" href="#rates" role="tab" aria-controls="rates" aria-selected="false"><i class="fa fa-money"></i>Rates & Fees</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="tab-4" data-toggle="tab" href="#FAQs" role="tab" aria-controls="FAQs" aria-selected="false"><i class="fa  fa-question-circle-o"></i>FAQs</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="tab-4" data-toggle="tab" href="#download" role="tab" aria-controls="download" aria-selected="false"><i class="fa fa-download"></i>Download</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="tab-4" data-toggle="tab" href="#getaquote" role="tab" aria-controls="getaquote" aria-selected="false"><i class="fa fa-coffee"></i>Get a Quote</a>
                                    </li>
                                </ul>


                            </div>
                            <!-- Tab panes -->
                            <div class="col-xl-9 col-lg-9 col-md-9 col-sm-12 col-12 nopadding">
                                <div class="tab-content">
                                    <div role="tabpanel" class="tab-pane active" id="overview">
                                        <h1>About Personal Loan</h1>
                                        <p class="lead mb60">Personal loan is the obvious choice if you need a finance for <strong>Personal finance, Medical emergency, Wedding purposes, Abroad travel, Holidays, Child education</strong> and for buying consumer durable things.</p>
                                        <p>Phasellus tellus nunc, sollicitudin quist amet it simple nequeuisque lacus mi tesimly diummy cintenbt mpus nec purus vitae tempor placerat leo.</p>
                                        <p>Aenean semper massa eu vestibulum feugiat, nm feugiat, nm feugiat, nuls simple dummy content la lum metus at ipsum gravida, at vehicula elit dapibus</p>
                                        <h3>Personal loan Benefits with borrow</h3>
                                        <ul class="listnone bullet bullet-check-circle-default">
                                            <li>Simplified Documentation</li>
                                            <li>Loan Disbursal in 48 hours*</li>
                                            <li>Transparent Processing</li>
                                            <li>Competitive Pricing</li>
                                        </ul>
                                        <p>Aenean semper massa eu vestibulum feugiat, nm feugiat, nm feugiat, nuls simple dummy content la lum metus at ipsum gravida, at vehicula elit dapibus</p>
                                        <a href="#" class="btn btn-default">Apply Now</a>
                                    </div>
                                    <div role="tabpanel" class="tab-pane" id="features">
                                        <h1>Features and Benefits of Loan</h1>
                                        <p class="lead mb60">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. </p>
                                        <div class="row">
                                            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                                                <div class="feature-icon mb30">
                                                    <div class="icon mb20"><i class="icon-clock icon-default icon-2x"></i></div>
                                                    <h3>Faster Loan</h3>
                                                    <p>For funding medical expenses, hospitalization, surgery, No collateral required. Sed eget accumsan justo. Nullam nisl nisi.</p>
                                                </div>
                                            </div>
                                            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                                                <div class="feature-icon mb30">
                                                    <div class="icon mb20"><i class="icon-light-bulb-1 icon-default icon-2x"></i></div>
                                                    <h3>Choose your amount</h3>
                                                    <p>All charges are communicated up front in writing along with the loan quotation uisque euismdolor at tincidunt lorem sipusm is simple.</p>
                                                </div>
                                            </div>
                                            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                                                <div class="feature-icon mb30">
                                                    <div class="icon mb20"><i class="icon-money icon-default icon-2x"></i></div>
                                                    <h3>Enjoy the best rates</h3>
                                                    <p>Our loan rates and charges are very attractive lorem ipsums sitamet uerse ipsum. Curabitu lectus mattis vitae. </p>
                                                </div>
                                            </div>
                                            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                                                <div class="feature-icon mb30">
                                                    <div class="icon mb20"><i class="icon-settings-6 icon-default icon-2x"></i></div>
                                                    <h3>Decide your tenure</h3>
                                                    <p>Our loan rates and charges are very attractive lorem ipsums sitamet uerse ipsum.Curabitulectus mattis vitae. </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div role="tabpanel" class="tab-pane" id="eligibility">
                                        <h1>Eligibility Criteria for Loan</h1>
                                        <p class="lead mb60">Any salaried, self-employed or professional Public and Privat companies, Government sector employees including Public Sector is eligible for a personal loan.</p>
                                        <p>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                                        <div class="row">
                                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                                <div class="feature-blurb mb30">
                                                    <h3>Age</h3>
                                                    <p>Maximum age of applicant at loan maturity: <strong>60 years</strong></p>
                                                </div>
                                            </div>
                                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                                <div class="feature-blurb mb30">
                                                    <h3>Income</h3>
                                                    <p>Minimum Net Monthly Income: <strong>Rs 25,000</strong></p>
                                                </div>
                                            </div>
                                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                                <div class="feature-blurb mb30">
                                                    <h3>Credit Rating</h3>
                                                    <p>Applicant should have the bank specified credit score. </p>
                                                </div>
                                            </div>
                                        </div>
                                        <a href="#" class="btn btn-default">Check Eligibility</a>
                                        <a href="#" class="btn btn-primary">Apply For Loan</a>
                                    </div>
                                    <div role="tabpanel" class="tab-pane" id="documentation">
                                        <h1>Documentation</h1>
                                        <p class="lead mb60">The following documents are required along with your Personal Loan application:</p>
                                        <ul class="list-group">
                                            <li class="list-group-item">Personal Identity proof (copy of passport/voter ID card/driving license/Aadhaar)
                                            </li>
                                            <li class="list-group-item">Home Address proof (copy of passport/voter ID card/driving license/Aadhaar)
                                            </li>
                                            <li class="list-group-item">Bank statement of previous 3 months (Passbook of previous 6 months
                                            </li>
                                            <li class="list-group-item">Latest salary slip/current dated salary certificate with the latest Form 16
                                            </li>
                                        </ul>
                                    </div>
                                    <div role="tabpanel" class="tab-pane" id="rates">
                                        <h1>Fees and charges</h1>
                                        <p class="lead mb60">Proin condimentum sagittis ligula, ac porttitor quam dictum in Below are fees and charges that you may be required to pay:</p>
                                        <div class="fees-table">
                                            <ul class="list-group">
                                                <li class="list-group-item">
                                                    <div class="row">
                                                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">
                                                            <h4>Types of fees</h4>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <h4>Charges applicable</h4>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="list-group-item">
                                                    <div class="row">
                                                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">Rate of interest</div>
                                                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">Up to 16% -35%</div>
                                                    </div>
                                                </li>
                                                <li class="list-group-item">
                                                    <div class="row">
                                                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">Processing fees</div>
                                                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">Up to 2%</div>
                                                    </div>
                                                </li>
                                                <li class="list-group-item">
                                                    <div class="row">
                                                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">Loan statement charges</div>
                                                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">Nil</div>
                                                    </div>
                                                </li>
                                                <li class="list-group-item">
                                                    <div class="row">
                                                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">Interest & principle statement charges</div>
                                                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">Nil</div>
                                                    </div>
                                                </li>
                                                <li class="list-group-item">
                                                    <div class="row">
                                                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">EMI bounce charges</div>
                                                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">$20 for every bounce</div>
                                                    </div>
                                                </li>
                                                <li class="list-group-item">
                                                    <div class="row">
                                                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">Secure fee</div>
                                                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">NA</div>
                                                    </div>
                                                </li>
                                            </ul>
                                        </div>
                                        <p>*Service Tax and other Government taxes, levies etc. applicable as per prevailing rate will be charged over and above the Fees and Charges</p>
                                        <a href="#" class="btn btn-primary">Apply For Loan</a>
                                    </div>
                                    <div role="tabpanel" class="tab-pane" id="FAQs">
                                        <h1>Frequently Asked Questions</h1>
                                        <p class="lead mb60">We are almost ready with your Frequently Asked Questions. Already we answered all question please check below may i will help to you.</p>
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 st-accordion col-xs-12">
                                                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading active" role="tab" id="headingOne">
                                                            <h4 class="panel-title"><a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne"><i class="fa fa-minus-circle sign"></i>Can I pay off my loan early? </a></h4>
                                                        </div>
                                                        <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                                            <div class="panel-body">
                                                                <p>Lorem ipsums sium congueut porttitor acese its commodo non lorem estibulum finibus urna eu efficitur non lorem acese its commodo sitamet finibus urnaeuloremmse its lorem ipusm dolro sit commodo.</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading" role="tab" id="headingTwo">
                                                            <h4 class="panel-title"><a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo"><i class="fa fa-plus-circle sign"></i>Do you offering refinancing ?</a> </h4>
                                                        </div>
                                                        <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                                                            <div class="panel-body">
                                                                <p>Aenean convallis, odio in eleifend tristique, sem nisl tincidunt magna, quis fermentum augue neque a diam. Praesent hendrerit risus a imperdiet viverra. Suspendisse sed lectus id arcu viverra interdum et in arcu.</p>
                                                                <p>Incidunt magna quis fermentum augue neque ullam vulputate, odio ac maximus consequat, nisl lorem maximus turpis, nec laoreet est ex vel elit. Sed placerat laoreet lobortis. a diam raesent hendrerit risus a imperdiet viverra uspendisse sed lectus id arcu viverra interdum et in arcu.</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading" role="tab" id="headingThree">
                                                            <h4 class="panel-title"><a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree"><i class="fa fa-plus-circle sign"></i>When should i apply? </a></h4>
                                                        </div>
                                                        <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                                                            <div class="panel-body">
                                                                <p>Incidunt magna quis fermentum augue neque ullam vulputate, odio ac maximus consequat, nisl lorem maximus turpis, nec laoreet est ex vel elit. Sed placerat laoreet lobortis. a diam raesent hendrerit risus a imperdiet viverra uspendisse sed lectus id arcu viverra interdum et in arcu.</p>
                                                                <ul>
                                                                    <li>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</li>
                                                                    <li>Cras imperdiet ligula ac elit sollicitudin scelerisque.</li>
                                                                    <li>Nunc viverra mi et risus dictum condimentum.</li>
                                                                    <li>Integer ac mi nec elit cursus rutrum ac in odio.</li>
                                                                    <li>Integer sit amet sapien dapibus libero finibus pellentesque eu at purus.</li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading" role="tab" id="headingFour">
                                                            <h4 class="panel-title"><a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseFour" aria-expanded="true" aria-controls="collapseFour"><i class="fa fa-plus-circle sign"></i>Where are you located?</a> </h4>
                                                        </div>
                                                        <div id="collapseFour" class="panel-collapse collapse " role="tabpanel" aria-labelledby="headingFour">
                                                            <div class="panel-body">
                                                                <p>Lorem ipsums sium congueut porttitor acese its commodo non lorem estibulum finibus urna eu efficitur non lorem acese its commodo sitamet finibus urnaeuloremmse its lorem ipusm dolro sit commodo.</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div role="tabpanel" class="tab-pane" id="download">
                                        <h1>Download loan forms now</h1>
                                        <p class="lead mb60">Fulfil your dreams to lead the life you want, the way you want with a personal loan! Download loan forms now!</p>
                                        <p>Enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                                        <ul class="listnone bullet list-pdf-file">
                                            <li><a href="#">Loan Application form</a></li>
                                            <li><a href="#">Loan Agreement</a></li>
                                            <li><a href="#">Income Certificate Issuing Authority</a></li>
                                            <li><a href="#">Download Form Link</a></li>
                                            <li><a href="#">Download Form Link</a></li>
                                        </ul>
                                        <a href="#" class="btn btn-default">Download Loan Brochure</a>
                                    </div>
                                    <div role="tabpanel" class="tab-pane" id="getaquote">
                                        <h1>Get A Quote</h1>
                                        <p class="lead mb60">Get quote easily just fill the below form and our one agent will contact you in 24 hours.</p>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <form class="">
                                                    <div class="row">
                                                        <!-- Text input-->
                                                        <div class="form-group col-md-4 col-sm-6 col-xs-12">
                                                            <label class="control-label" for="name">Name</label>
                                                            <div class="">
                                                                <input id="name" name="name" type="text" placeholder="Name" class="form-control input-md" required>
                                                                <span class="help-block"></span>
                                                            </div>
                                                        </div>
                                                        <!-- Text input-->
                                                        <div class="form-group col-md-4 col-sm-6 col-xs-12">
                                                            <label class=" control-label" for="email">E-Mail</label>
                                                            <div class="">
                                                                <input id="email" name="email" type="text" placeholder="E-mail" class="form-control input-md">
                                                            </div>
                                                        </div>
                                                        <!-- Text input-->
                                                        <div class="form-group col-md-4 col-sm-12 col-xs-12">
                                                            <label class="control-label" for="phone">Phone</label>
                                                            <div class="">
                                                                <input id="phone" name="phone" type="text" placeholder="Phone" class="form-control">
                                                            </div>
                                                        </div>
                                                        <div class="form-group col-md-6 col-sm-12 slide-ranger col-xs-12">
                                                            <p id="slider-range-min"></p>
                                                            <label for="amount" class="control-label">Loan Amount</label>
                                                            <input type="text" id="amount" readonly class="form-control">
                                                        </div>
                                                        <div class="form-group col-md-6 col-sm-12 slide-ranger col-xs-12">
                                                            <p id="slider-range-max"></p>
                                                            <label for="amount" class="control-label">Year</label>
                                                            <input type="text" id="j" readonly class="form-control">
                                                        </div>
                                                        <!-- Button -->
                                                        <div class="form-group col-md-4 col-sm-6 col-xs-12">
                                                            <div class="">
                                                                <button id="Submit" name="Submit" class="btn btn-primary btn-block">Submit New Quote</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
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

