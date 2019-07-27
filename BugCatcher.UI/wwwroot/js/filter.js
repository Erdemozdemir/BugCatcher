$(document).ready(function () {
    $('.filterable').keyup(function (e) {
        /* Ignore tab key */
        var code = e.keyCode || e.which;
        if (code == '9') return;

        var $table = $('.table');
        var $rows = $table.find('tbody tr');

        $rows.show();

        var inputWithValue = $('.filterable').each(function (e) {
            if ($(this).val() !== '') {

                /* Useful DOM data and selectors */
                var $input = $(this),
                    inputContent = $input.val().toLowerCase(),
                    column = $table.find('.filters th').index($input.parents('th'));

                var $filteredRows = $rows.filter(function () {
                    var el = $(this).find('td').eq(column);
                    var value = "";

                    var elControl = $(el)[0].firstChild;

                    if (!$(elControl).is('select')) {
                        console.log("input")
                        value = $(el).text().toLowerCase();
                    }
                    else {
                        value = $(elControl).find(":selected").text().toLowerCase();
                        console.log("select")
                    }

                    return value.indexOf(inputContent) === -1;
                });

                $filteredRows.hide();
            }
        });

    });
});