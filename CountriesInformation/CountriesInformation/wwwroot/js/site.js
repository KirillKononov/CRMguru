function loadAndSaveNewCountry(name) {
    $.getJSON(`https://restcountries.eu/rest/v2/name/${name}`,
        (data) => {
            displayNewCountry(data);
            setTimeout(() => {
                if (confirm("Do you want to save this country or the first one if there is more than one in the database?")) {
                    saveCountryToDb(data);
                }
            }, 500);
        })
        .fail(document.getElementById("content").innerHTML = `There is no country with name ${$("#countryName").val()}`);
};

function loadCountriesFromDb() {
    $.getJSON("/Home/GetAll",
        (data) => {
            displayCountriesFromDb(data);
        });
}

function getTableHead() {
    return `<tr>
        <th><label>Name</label><th>
        <th><label>Code</label><th>
        <th><label>Capital</label><th>
        <th><label>Area</label><th>
        <th><label>Population</label><th>
        <th><label>Region</label><th>
        <tr>`;
}

function displayCountriesFromDb(countries) {
    let table = '<table class="table">';
    table += getTableHead();
    countries.forEach(country => {
        const tableRow = `<tr>
        <td>${country.name}<td>
        <td>${country.code}<td>
        <td>${country.capital.name}<td>
        <td>${country.area}<td>
        <td>${country.population}<td>
        <td>${country.region.name}<td>
        <tr>`;
        table += tableRow;
    });
    table += "</table>";
    $("#content").html(table);
}

function displayNewCountry(countries) {
    let table = '<table class="table">';
    table += getTableHead();
    countries.forEach(country => {
        const tableRow = `<tr>
        <td>${country.name}<td>
        <td>${country.alpha3Code}<td>
        <td>${country.capital}<td>
        <td>${country.area}<td>
        <td>${country.population}<td>
        <td>${country.region}<td>
        <tr>`;
        table += tableRow;
    });
    table += "</table>";
    $("#content").html(table);
};

function saveCountryToDb(countriesToSave) {
    const newCountry = {
        name: countriesToSave[0].name,
        code: countriesToSave[0].alpha3Code,
        capital: {
            name: countriesToSave[0].capital
        },
        area: countriesToSave[0].area,
        population: countriesToSave[0].population,
        region: {
            name: countriesToSave[0].region
        }
    };

    $.ajax({
        url: "Home/Post",
        type: "POST",
        data: { countryViewModel: newCountry },
        success: (data) => {
            alert(`New country ${data.name} added to the database`);
        }
    });
}

window.onload = () => {
    $("#submitCountryName").click(() => {
        const countryName = $("#countryName").val();
        loadAndSaveNewCountry(countryName);
    });

    $("#countriesFromDb").click(() => {
        loadCountriesFromDb();
    });
}