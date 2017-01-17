<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFlicbox.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="flicboxPWC_CMS.about" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="about">

        <div class="parallax-section">
            <div class="parallax-about"></div>
            <div class="just_pattern"></div>
            <div class="container z-index-pages">
                <div class="sixteen columns" data-scrollreveal="enter top and move 250px over 3s">
                    <h1>about us</h1>
                </div>
                <div class="sixteen columns">
                    <div class="text-line-pages"></div>
                </div>
                <div class="sixteen columns" data-scrollreveal="enter bottom and move 250px over 3s">
                    <ul class="flippy">
                        <li>
                            <div class="small-text-pages">Awesome chocolates monthly</div>
                        </li>
                        <li>
                            <div class="small-text-pages">Awesome chocolates monthly</div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="top-section">
            <div class="container">
                <div class="sixteen columns" data-scrollreveal="enter top and move 250px over 3s">
                    <p>
                        Get amazing chocolates every month right at your doorstep.
                        International brands and handmade gourmet chocolates included.
                        Pick any one of our sizes – Little, Medium & Giant and make it a monthly plan.
                        Also gift your friends, family or loved ones any of our chocolate bags for any occasion.
                        Want to try a plan before you subscribe? Just make a 1 time purchase from “1timebuy” tab.
                        Get amazing seasonal discounts every now and then. We like our subscribers happy!
                        Going out of town? Pause your subscription for a maximum of thirty days.
                        Cancel your subscription anytime. No hidden costs included.
                        No hassle, No commitment, No conract!
                    </p>
                </div>

            </div>
        </div>

    </div>


    <div class="parallax-section" id="howitworks">
        <div class="parallax-about-down"></div>
        <div class="just_pattern"></div>
        <div class="video-play-section">
            <div class="container z-index-pages">
                <div class="sixteen columns" data-scrollreveal="enter top and move 250px over 1.5s">
                    <h5>How It Works</h5>
                </div>
                <div class="sixteen columns">
                    <div class="text-line-pages"></div>
                </div>
                <div class="sixteen columns" data-scrollreveal="enter bottom and move 250px over 1.5s">
                    <div id="sync3" class="owl-carousel">
                        <div class="item">
                            <img src="images/subscribe-a-plan.jpg" alt="subscribe a plan - Flicbox" />
                            <div class="over-image">
                                <h6>Subscribe A Plan</h6>
                                <p>Once you have decided on the best plan for you or your family, subscribe for monthly chocolates.
                                    <br />We have three amazing plans for you.</p>
                            </div>
                        </div>
                        <div class="item">
                            <img src="images/personal-curation.jpg" alt="Personal Curation - Flicbox" />
                            <div class="over-image">
                                <h6>Personal Curation</h6>
                                <p>We personally curate each and every box to make it special for you.</p>
                            </div>
                        </div>
                        <div class="item">
                            <img src="images/delivery.jpg" alt="Delivery - Flicbox" />
                            <div class="over-image">
                                <h6>The Delivery</h6>
                                <p>Chocolates are delivered to you cold and fresh. Pause or cancel your subscription anytime.</p>
                            </div>
                        </div>
                    </div>
                    <div id="sync4" class="owl-carousel">
                        <div class="item"></div>
                        <div class="item"></div>
                        <div class="item"></div>
                        <div class="item"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="work-together-section">
        <div class="container">
            <div class="sixteen columns" data-scrollreveal="enter bottom and move 250px over 1.5s">
                <div class="sections-link-pages">
                    <div class="cl-effect-11"><a href="#" data-hover="Subscribe">Subscribe</a></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
