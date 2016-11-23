// function to transfer data to update company form
function passUpdateDataToForm(id, name, earnings, type, parentCompany) {
    document.forms[1].childNodes[2].childNodes[3].value = id;
    document.forms[1].childNodes[4].childNodes[3].value = name;
    document.forms[1].childNodes[6].childNodes[3].value = earnings;
    document.getElementById("updateCompanyType").value = type.toString();
    document.getElementById("ParentCompanyId").value = parentCompany.toString();
    window.scrollTo(0, 0);
}

// function to validate Add Company Form
function validateAddCompanyForm() {
    var form = document.forms[0];

    // get data from form and pass it to the function
    return validateTextFields(form.childNodes[2].childNodes[3].value,
            form.childNodes[4].childNodes[3].value,
            form.childNodes[6].childNodes[3].value,
            form.childNodes[8].childNodes[3].value);
}

// function to validate Update Company Form
function validateUpdateCompanyForm() {
    var form = document.forms[1];
    var error = "";
    
    // get data from form and pass it to the function
    var isValid = validateTextFields(form.childNodes[4].childNodes[3].value,
                    form.childNodes[6].childNodes[3].value,
                    form.childNodes[8].childNodes[3].value,
                    form.childNodes[10].childNodes[3].value);

    // convert Ids to string
    var companyToChange = form.childNodes[2].childNodes[3].value + "";
    var parentComany = document.getElementById("ParentCompanyId").value + "";

    // compare that user doedn't try to make a company a parent of itself
    if (isValid && (companyToChange === parentComany)) {
        error += "Invalid parent company\n";
        isValid = false;
        alert(error);
    }
    
    // if false - cancel submitting, true - transfer data to back-end
    return isValid;
}

// validate text fields
function validateTextFields(name, earnings, companyType, parentCompany) {
    var isValid = true;
    var error = "Error:\n";

    if (name === "" || name.length > 100) {
        
        error += "Invalid name\n";
        isValid = false;
    }

    if (earnings === "" || isNaN(Number(earnings))) {
        error += "Invalid earnings\n";
        isValid = false;
    }

    if (companyType !== "Main" && companyType !== "Subsidiary") {
        error += "Please select company type\n";
        isValid = false;
    }

    if (companyType === "Subsidiary" && parentCompany === "") {
        error += "Please select parent company\n";
        isValid = false;
    }

    if (!isValid) {
        alert(error);
        return false;
    }

    return isValid;
}

// verify that company does not have child companies
function validateDeleteCompany(isWithChild, isWithSubsidiary) {

    if (isWithChild === "True" || isWithSubsidiary === "True") {
        alert("Error: Delete child companies first");
        return false;
    }
    
    return true;
}