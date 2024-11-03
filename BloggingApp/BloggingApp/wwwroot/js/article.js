fetch("/home/getall")
    .then(response => response.json())
    .then(x => display(x));

function display(data) {
    let placeHolders = document.querySelector(".list-unstyled").querySelectorAll("li");

    let options = { year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit' };

    data.sort((a, b) => new Date(b.date) - new Date(a.date));

    let currentArticleId = document.getElementById("articleId").value;
    data = data.filter(x => x.id != currentArticleId);

    let top3 = data.slice(0, 3);

    for (let i = 0; i < placeHolders.length; i++) {
        let current = placeHolders[i];
        let href = current.querySelector("a").getAttribute("href");
        href = href.slice(0, href.length - 1);
        href += top3[i].id;

        current.querySelector("a").setAttribute("href", href);
        current.querySelector("h6").innerText = top3[i].title;
        current.querySelector("small").innerText = new Date(top3[i].date).toLocaleString("en-US", options);
    }
}

$('#deleteModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})