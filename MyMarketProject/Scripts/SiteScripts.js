document.querySelector(".SortBy").addEventListener("click", function (e) {
    if (e.target.tagName == "BUTTON" && e.target.classList.contains("SortByBtnLink")) {
        if (e.target.classList.contains("Active")) {
            return;
        }
        else {
            let SortByBtns = document.querySelectorAll(".SortByBtnLink");
            for (let btn of SortByBtns) {
                if (btn.classList.contains("Active")) {
                    btn.classList.remove("Active")
                }
            }
            e.target.classList.add("Active");
            document.cookie = "SortByAttr=" + e.target.dataset.sortBy;
            window.location.reload();
        }

    }
});
if ($.cookie("SortByAttr") != undefined) {
    let SortByBtns = document.querySelectorAll(".SortByBtnLink");
    for (let btn of SortByBtns) {
        if (btn.classList.contains("Active")) {
            btn.classList.remove("Active")
        }
        if (btn.dataset.sortBy == $.cookie("SortByAttr")) {
            btn.classList.add("Active");
        }
    }
}
document.querySelector(".sidebar").addEventListener("click", function (e) {
    if (e.target.tagName == "BUTTON" && e.target.classList.contains("SidebarFilterInputOK")) {
        $.cookie("RangeMin", document.querySelector("#RangeMin").value);
        $.cookie("RangeMax", document.querySelector("#RangeMax").value);
        window.location.reload();
    }
    if (e.target.tagName == "BUTTON" && e.target.classList.contains("ClearForm")) {
        $.cookie("RangeMin", "");
        document.querySelector("#RangeMin").value = "";
        $.cookie("RangeMax", "");
        document.querySelector("#RangeMax").value = "";
        window.location.reload();
    }
})
document.querySelector(".AP-Nav").addEventListener("click", function (e) {
    if (e.target.tagName == "INPUT" && e.target.classList.contains("AP-btn")) {
        let CurrentLi = e.target.closest(".AP-Nav-Li");
        if (CurrentLi.classList.contains("Active")) {
            return;
        }
        else {
            let lis = document.querySelectorAll(".AP-Nav-Li");
            for (let li of lis) {
                if (li.classList.contains("Active")) {
                    li.classList.remove("Active");
                }
            }
            CurrentLi.classList.add("Active");
        }
    }
});
