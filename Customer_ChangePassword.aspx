<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Customer_ChangePassword.aspx.cs" Inherits="AdvancedWebDevelopment.Customer_ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<section class="vh-100">
  <div class="container py-5 h-100">
    <div class="row d-flex align-items-center justify-content-center h-100">
      <div class="col-md-7 col-lg-5 col-xl-5">
           <!-- Test input -->



          <!-- Password input -->
          <div class="form-outline mb-7">
            <asp:TextBox ClientID="password" ID="password" CssClass="form-control form-control-lg" TextMode="Password" runat="server" pattern='(?=.*\d)(?=.*[a-z])(?=.*[0-9])(?=.*[A-Z])(?=.*[!@#$%^&*]).{8,}'></asp:TextBox>
            <label class="form-label" for="password">Password</label>
        
          </div>
            <div id="message">
                    <p id="letter" class="invalid">A <b>lowercase</b> letter</p>
                    <p id="capital" class="invalid">A <b>uppercase</b> letter</p>
                    <p id="number" class="invalid">A <b>number</b></p>
                    <p id="length" class="invalid">Minimum <b>8 characters</p>
                    <p id="symbol" class="invalid">1 special character</p>
               </div>
          <!-- cONFIRM Password input -->
          <div class="form-outline mb-7">
            <asp:TextBox ID="password2" CssClass="form-control form-control-lg" TextMode="Password" runat="server"></asp:TextBox>
            <label class="form-label" for="password2">Confirm Password</label>
          </div>
            <asp:CompareValidator ID="CompareValidatorPW" runat="server" ErrorMessage="Passwords must match!" ControlToValidate="password2" ControlToCompare="password" Operator="Equal" Type="String" ForeColor="Red"></asp:CompareValidator>
          <div class="d-flex justify-content-around align-items-center mb-4">
            <!-- Checkbox -->
          </div>

          <!-- Submit button -->
          <asp:Button ID="btnchangepwd" text="Change" class="btn btn-dark btn-lg btn-block" runat=server OnClick="btnchangepw_Click" />

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
      </div>
    </div>
  </div>
</section>
    <script>
        var myInput = document.getElementById("<%= password.ClientID %>");
        var letter = document.getElementById("letter");
        var capital = document.getElementById("capital");
        var number = document.getElementById("number");
        var length = document.getElementById("length");
        var symbol = document.getElementById("symbol");

        // When the user clicks on the password field, show the message box
        myInput.onfocus = function () {
            document.getElementById("message").style.display = "block";
        }

        // When the user clicks outside of the password field, hide the message box
        myInput.onblur = function () {
            document.getElementById("message").style.display = "none";
        }

        // When the user starts to type something inside the password field
        myInput.onkeyup = function () {
            // Validate lowercase letters
            var lowerCaseLetters = /[a-z]/g;
            if (myInput.value.match(lowerCaseLetters)) {
                letter.classList.remove("invalid");
                letter.classList.add("valid");
            } else {
                letter.classList.remove("valid");
                letter.classList.add("invalid");
            }

            // Validate capital letters
            var upperCaseLetters = /[A-Z]/g;
            if (myInput.value.match(upperCaseLetters)) {
                capital.classList.remove("invalid");
                capital.classList.add("valid");
            } else {
                capital.classList.remove("valid");
                capital.classList.add("invalid");
            }

            // Validate numbers
            var numbers = /[0-9]/g;
            if (myInput.value.match(numbers)) {
                number.classList.remove("invalid");
                number.classList.add("valid");
            } else {
                number.classList.remove("valid");
                number.classList.add("invalid");
            }
            // Validate special characters 
            var symbols = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/g;
            if (myInput.value.match(symbols)) {
                symbol.classList.remove("invalid");
                symbol.classList.add("valid");
            } else {
                symbol.classList.remove("valid");
                symbol.classList.add("invalid");
            }

            // Validate length
            if (myInput.value.length >= 8) {
                length.classList.remove("invalid");
                length.classList.add("valid");
            } else {
                length.classList.remove("valid");
                length.classList.add("invalid");
            }
        }
    </script>
    <style>

    
      /* The message box is shown when the user clicks on the password field */
      #message {
        display:none;
        background: white;
        color: #000;
        position: relative;
        padding: 10px;
        padding-left: 40px;
        margin-top: -15px;
        padding-bottom: 9px;
      }
      
      #message p {
        padding: -15px -15px;
        font-size: 13px;
      }
      
      /* Add a green text color and a checkmark when the requirements are right */
      .valid {
        color: green;
      }
      
      .valid:before {
        position: relative;
        left: -30px;
        content: "✔";
      }
      
      /* Add a red text color and an "x" when the requirements are wrong */
      .invalid {
        color: red;
      }
      
      .invalid:before {
        position: relative;
        left: -30px;
        content: "X";
      }
      </style>
</asp:Content>
