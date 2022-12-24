<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Customer_Register.aspx.cs" Inherits="AdvancedWebDevelopment.Customer_Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .divider:after,
.divider:before {
content: "";
flex: 1;
height: 1px;
background: #eee;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section class="vh-100">
  <div class="container py-5 h-100">
    <div class="row d-flex align-items-center justify-content-center h-100">
      <div class="col-md-7 col-lg-5 col-xl-5">
        <form>
           <!-- Name input -->
          <div class="form-outline mb-7">
            <input type="name" id="form1Example1" class="form-control form-control-lg" />
            <label class="form-label" for="form1Example13">Name</label>
          </div>

          <!-- Email input -->
          <div class="form-outline mb-7">
            <input type="email" id="form1Example13" class="form-control form-control-lg" />
            <label class="form-label" for="form1Example13">Email address</label>
          </div>

          <!-- Password input -->
          <div class="form-outline mb-7">
            <input type="password" id="form1Example23" class="form-control form-control-lg" />
            <label class="form-label" for="form1Example23">Password</label>
          </div>

          <!-- cONFIRM Password input -->
          <div class="form-outline mb-7">
            <input type="password" id="form1Exawa3" class="form-control form-control-lg" />
            <label class="form-label" for="form1Example23">Confirm Password</label>
          </div>

          <div class="d-flex justify-content-around align-items-center mb-4">
            <!-- Checkbox -->
          </div>

          <!-- Submit button -->
          <button type="submit" class="btn btn-dark btn-lg btn-block">Register</button>
             <div class="row d-flex align-items-center justify-content-center">
              <a href="Customer_Login.aspx">Aready have an account? Login</a>
          </div>
         <%-- <div class="divider d-flex align-items-center my-4">
            <p class="text-center fw-bold mx-3 mb-0 text-muted">OR</p>
          </div>

          <a class="btn btn-primary btn-lg btn-block" style="background-color: #3b5998" href="#!"
            role="button">
            <i class="fab fa-facebook-f me-2"></i>Continue with Facebook
          </a>
          <a class="btn btn-primary btn-lg btn-block" style="background-color: #55acee" href="#!"
            role="button">
            <i class="fab fa-twitter me-2"></i>Continue with Twitter</a>--%>

        </form>
      </div>
    </div>
  </div>
</section>
</asp:Content>
