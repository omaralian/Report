$("#exportToCsv").click(function () {
    $("table").table2csv({
        separator: ',',
        newline: '\n',
        quoteFields: true,
        excludeColumns: '',
        excludeRows: '',
        trimContent: true // Trims the content of individual <th>, <td> tags of whitespaces.
    });
});
