function countChar(src, dst, max) {
    let inputEl = $(src);
    let dstEl = $(dst);
    let text = inputEl.val();
    var len = text.length;
    if (len > max) {
        inputEl.val(text.substring(0, max));
        len = inputEl.val().length;
    }
    dstEl.find('span').first().text(len);
    dstEl.find('span').last().text(max);

};

$(document).on("keyup", "#edit-desc,#create-desc", (e) => {
    let id = $(e.currentTarget).attr('id');
    countChar('#' + id, '#' + id+'-counter');
});