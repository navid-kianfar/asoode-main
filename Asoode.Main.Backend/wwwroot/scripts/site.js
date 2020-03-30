(function($, window, document, undefined){
    const win = $(window);
    const allMods = $(".feature");

    allMods.each(function(i, e) {
        const el = $(e);
        if (el.visible(true)) {
            el.addClass("already-visible");
        }
    });

    win.scroll(function(event) {
        allMods.each(function(i, e) {
            const el = $(e);
            if (el.visible(true)) {
                el.addClass("come-in");
            }
        });

    });
})(jQuery, window, document);