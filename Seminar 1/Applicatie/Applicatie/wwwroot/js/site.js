var onClickRowTimer;

$(document).ready(function () {

    let tableRowSelector = jid("table") + " tbody tr";

    $(tableRowSelector).click(function () {
        if (onClickRowTimer) clearTimeout(onClickRowTimer);
        let me = this;

        onClickRowTimer = setTimeout(function () {
            let selected = $(me).hasClass("tableSelectedRow");
            $(tableRowSelector).removeClass("tableSelectedRow");
            if (!selected)
                $(me).addClass("tableSelectedRow");
        }, 250);
    });

    // Disable scroll when focused on a number input.
    $('body').on('focus', 'input[type=number]', function (e) {
        $(this).on('wheel', function (e) {
            e.preventDefault();
        });
    });

    // Restore scroll on number inputs.
    $('body').on('blur', 'input[type=number]', function (e) {
        $(this).off('wheel');
    });

    // Disable up and down keys.
    $('body').on('keydown', 'input[type=number]', function (e) {
        if (e.which == 38 || e.which == 40)
            e.preventDefault();
    });
});

// escape invalid chars in ids
function jid(id) {
    return "#" + id.replace(/(:|\.|\[|\])/g, "\\$1");
}

function stringFormat() {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i += 1) {
        var reg = new RegExp('\\{' + i + '\\}', 'gm');
        s = s.replace(reg, arguments[i + 1]);
    }
    return s;
};

function getSelectedRow() {
    return $(jid("table") + " tbody tr.tableSelectedRow");
}

function getSelectedId() {
    let selectedRow = getSelectedRow();

    if (!selectedRow || selectedRow.length !== 1) {
        alert("You must select a row");
        return null;
    }

    return selectedRow[0].id
}

function callEditUrl(editUrl, selectedId) {

    if (!selectedId || !editUrl)
        return;

    let url = stringFormat(editUrl, selectedId);
    window.open(url, "_self");
}

function openEditWindowOnBtnEditClick(editUrl) {

    callEditUrl(editUrl, getSelectedId());
}

function openEditWindowOnDlbClick(editUrl, selectedId) {

    clearTimeout(onClickRowTimer);
    callEditUrl(editUrl, selectedId)
}

function onDelete(deleteUrl) {

    let selectedId = getSelectedId();
    if (!selectedId)
        return;

    $.ajax({
        url: stringFormat(deleteUrl, selectedId),
        data: { "id": selectedId },
        type: 'delete',
        success: function (data) {
            if (data.success)
                $(jid(selectedId)).remove();
        },
        error: function (context, status, message) {
            alert(message);
        }
    })
}

function onFormSubmit() {

    $('form').submit();
}

function onNextPrevClick(isNextPage, idInputNextPageNumber) {

    let currentPageInput = $(jid(idInputNextPageNumber));
    if (!currentPageInput)
        return;

    let currentValue = parseInt(currentPageInput.val());
    let pageNumber = isNextPage ? currentValue + 1 : currentValue - 1
    currentPageInput.val(pageNumber);

    onFormSubmit();
}

function onEnterFilterPress() {

    $('input').on('keypress', function (e) {

        if (e.which === 13)
            onFormSubmit();
    });
}
