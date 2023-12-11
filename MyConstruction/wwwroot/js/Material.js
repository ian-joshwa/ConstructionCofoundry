

let stockList = document.getElementById("StockList");


function stockListValue(projectId) {
    stockList.addEventListener("change", function () {
        var selectedValue = stockList.value;

        fetch(`/GetPreviousStock?projectId=${projectId}&stockId=${selectedValue}`)
            .then(response => response.json())
            .then(data => {
                var PreviousStock = document.getElementById("PreviousStock");
                PreviousStock.value = data;

            })
            .catch(error => {

            });
    });
}


