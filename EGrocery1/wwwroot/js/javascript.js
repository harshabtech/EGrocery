
function validate()
{
    var fname = document.getElementById("fname").value;
    var lname = document.getElementById("lname").value;
   
    var password = document.getElementById("password").value;
    var rpassword = document.getElementById("rpassword").value;
    
    var email = document.getElementById("email").value;

    var namePattern = new RegExp("[a-zA-Z]{2,20}");
    var userPattern = new RegExp("[a-zA-Z0-9]{5,8}");
    var passPattern = new RegExp("[a-zA-Z0-9]{2,8}[@!#$%^&*]{1,3}");
    var phnoPattern = new RegExp("(7|8|9){1}[0-9]{9}");
    var emailPattern = new RegExp("^([a-zA-Z0-9\.]{2,50})@[a-zA-Z]{2,20}(.(com|in){1})$");

    if (!(namePattern.test(fname.trim())))
    {
        alert("Please provide a valid first name!. length should be in between 2-20 letters");
        document.getElementById("fname").focus();
        return false;
    } 

    else if (!(namePattern.test(lname.trim())))
    {
        alert("Please provide a valid last name!. length should be in between 2-20 letters");
        document.getElementById("lname").focus();
        return false;
    }
    

    else if (!(passPattern.test(password.trim())))
    {
        alert("password should be minimum of length 6 and atleast contain one special charcter.");
        document.getElementById("password").focus();
        return false;
    }
    else if (!(passPattern.test(rpassword.trim())))
    {
        alert("password should be minimum of length 6 and atleast contain one special charcter.");
        document.getElementById("rpassword").focus();
        return false;
    }
    else if (rpassword.trim() != password)
    {
        alert("password mismatch");
        document.getElementById("rpassword").focus();
        document.getElementById("rpassword").style.color = "red";
        return false;
    }
    else
    {
        
        return true;
    }
}

