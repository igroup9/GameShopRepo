function initializeCarousel() {
  const carousels = document.querySelectorAll(
    ".image-carousel"
  );

  carousels.forEach((carousel) => {
    const images = carousel.querySelectorAll(
      ".carousel-image"
    );
    const prevButton = carousel.querySelector(".prev");
    const nextButton = carousel.querySelector(".next");
    let currentIndex = 0;

    function showImage(index) {
      images.forEach((img, i) => {
        img.style.display = i === index ? "block" : "none";
      });
    }

    prevButton.addEventListener("click", () => {
      currentIndex =
        (currentIndex - 1 + images.length) % images.length;
      showImage(currentIndex);
    });

    nextButton.addEventListener("click", () => {
      currentIndex = (currentIndex + 1) % images.length;
      showImage(currentIndex);
    });

    showImage(currentIndex);
  });
}

function renderGames(games) {
  const gamesList = document.getElementById(
    "games_container"
  );

  if (!gamesList) {
    console.error("games_container not found in the HTML!");
    return;
  }

  games.forEach((G, index) => {
    const gameCard = document.createElement("div");
    gameCard.className = "game-card";

    gameCard.innerHTML = `
      <img src="${G.Header_image}" alt="${
      G.Name
    }" class="game-header-image">
      <h2>${G.Name}</h2>
      <p><strong>App ID:</strong> ${G.AppID}</p>
      <p><strong>Release Date:</strong> ${
        G.Release_date
      }</p>
      <p><strong>Price:</strong> $${G.Price.toFixed(2)}</p>
      <p><strong>Description:</strong> ${G.description}</p>
      <p><strong>Full Audio Languages:</strong> ${
        G.Full_audio_languages
      }</p>
      <p><strong>Developers:</strong> ${G.Developers}</p>
      <p><strong>Categories:</strong> ${G.Categories}</p>
      <p><strong>Genres:</strong> ${G.Genres}</p>
      <p><strong>Tags:</strong> ${G.Tags}</p>
      <p><strong>Score Rank:</strong> ${G.Score_rank}</p>
      <p><strong>Platforms:</strong>
        ${G.Windows === "TRUE" ? "Windows " : ""}
        ${G.Mac === "TRUE" ? "Mac " : ""}
        ${G.Linux === "TRUE" ? "Linux" : ""}
      </p>
      <a href="${
        G.Website
      }" target="_blank">Official Website</a>
      <div class="screenshots image-carousel">
        ${G.Screenshots.split(",")
          .map(
            (url, index) =>
              `<img src="${url}" alt="Screenshot" class="carousel-image ${
                index === 0 ? "active" : ""
              }" style="width:100%; display: ${
                index === 0 ? "block" : "none"
              };">`
          )
          .join("")}
        <button class="carousel-button prev">&lt;</button>
        <button class="carousel-button next">&gt;</button>
      </div>
      <button class="add_to_list_btn" data-index="${index}">Add To Your List</button>
    `;

    gamesList.appendChild(gameCard);
  });
}

const api = "https://localhost:7119/api/Games";
function postToServer(game) {
  ajaxCall(
    "POST",
    api,
    JSON.stringify(game),
    postGameSCB,
    postGameECB
  );

  function postGameSCB(status) {
    console.log(status);
    if (status) alert("Game Added successfully");
    else alert("Game already in the game list");
  }
  function postGameECB(ERR) {
    console.log(ERR);
  }
}
