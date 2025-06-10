let loadingAnim = document.getElementById("Loading");

let list: any[] = [];

interface ApiConfig {
    api: string; // The key in your JSON is 'api'
}


let api: string = ""; // This variable will hold your NewsAPI key

// --- Asynchronous API Key Loading ---
(async () => {
    try {
        const response = await fetch('api.json');
        const json: ApiConfig = await response.json(); // Type the JSON response
        api = json.api; // Correctly access the 'api' key from your JSON
    } catch (error) {
        console.error("Error loading API key from api.json:", error);
        // Display a user-friendly error message if the API key can't be loaded
        if (document.getElementById("headlinesContainer")) { // Assuming you have this ID for the main content area
            document.getElementById("headlinesContainer")!.innerHTML = "<div>Error loading API configuration. News cannot be displayed.</div>";
        }
    }
})();

// --- getHeadLines function (corrected URL construction) ---
async function getHeadLines(baseUrl: string) {
    // --- IMPORTANT: Check if API key is loaded before making the fetch call ---
    if (!api) {
        console.error("API Key not loaded yet. Cannot fetch headlines.");
        if (loadingAnim) loadingAnim.style.display = "none";
        // Optionally display a message to the user that the API key isn't ready
        return;
    }

    try {
        if (loadingAnim) loadingAnim.style.display = "flex";
        
        // --- Correctly construct the URL by appending the loaded API key ---
        const url = `${baseUrl}&apiKey=${api}`;
        
        const response = await fetch(url);
        // ... rest of your error handling and data processing ...
        const data = await response.json();
        if (!response.ok) {
            // Handle API errors (e.g., invalid API key, quota exceeded)
            const errorDetails = data?.message || response.statusText;
            throw new Error(`News API Error: ${response.status} - ${errorDetails}`);
        }

        if (loadingAnim) loadingAnim.style.display = "none";

        const headlinesContainer = document.getElementById("headLines");
        if (headlinesContainer) {
            headlinesContainer.innerHTML = "";
            if (data.articles && data.articles.length > 0) {
                list = data.articles;
                currentPage = 1; // Reset to first page after fetching
                renderUsers();

            } else {
                list = [];
                headlinesContainer.innerHTML = "<div>No headlines found.</div>";
            }
        }
    } catch (error) {
        if (loadingAnim) loadingAnim.style.display = "none";
        console.error("Headline fetch error:", error);
        list = []; // Clear list on error
        if (document.getElementById("headLines")) {
            document.getElementById("headLines")!.innerHTML = `<div>Error fetching headlines: ${(error as Error).message}. Please try again later.</div>`;
        }
    }
}

let currentPage = 1;
const itemsPerPage = 10;

const headLines = document.getElementById("headLines");
const pageInfo = document.getElementById("CurrPage");
const prevBtn = document.getElementById("Prev");
const nextBtn = document.getElementById("Next");

function renderUsers() {
    if (!list || !Array.isArray(list) || list.length === 0) {
        if (headLines) headLines.innerHTML = "<div>No headlines found.</div>";
        if (pageInfo) pageInfo.textContent = "";
        return;
    }

    if (headLines) headLines.innerHTML = "";
    const start = (currentPage - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const forecastPage = list.slice(start, end);

    const headlinesContainer = document.getElementById("headLines");
    if (headlinesContainer)
        forecastPage.forEach((article: any) => {
            const item = document.createElement("a");
            item.className = "HeadLineItem";
            item.href = article.url || "#";
            item.target = "_blank";
            item.rel = "noopener noreferrer"; // Security best practice
            item.innerHTML = `
                <img class="ImgDescription" src="${article.urlToImage ? article.urlToImage : "Img/Gemini_Generated_Image_swgtsqswgtsqswgt.png"}" alt="">
                <div class="Descrioption">
                    <p class="Title">${article.title || "No Title"}</p>
                    <p class="Source">${article.source?.name || "Unknown Source"}</p>
                    <p class="Date">${article.publishedAt ? new Date(article.publishedAt).toLocaleDateString() : ""}</p>
                </div>
            `;
            headlinesContainer.appendChild(item);
        });

    const totalPages = Math.ceil(list.length / itemsPerPage);
    if (pageInfo)
        pageInfo.textContent = `Page ${currentPage} of ${totalPages}`;

}

if (prevBtn)
    prevBtn.addEventListener("click", () => {
        if (currentPage > 1) {
            currentPage--;
            renderUsers();
        }
    });

if (nextBtn)
    nextBtn.addEventListener("click", () => {
        const totalPages = Math.ceil(list.length / itemsPerPage);
        if (currentPage < totalPages) {
            currentPage++;
            renderUsers();
        }
    });

// --- Initial Data Load on DOMContentLoaded (corrected URL) ---
document.addEventListener("DOMContentLoaded", async () => {
    // Wait for the 'api' key to be loaded before attempting the initial fetch
    while (!api) {
        await new Promise(resolve => setTimeout(resolve, 50)); // Wait a bit
    }
    console.log("Initial fetch triggered.");
    await getHeadLines(`https://newsapi.org/v2/top-headlines?country=us`); // getHeadLines will append the key
});

// --- Category Base URLs (without the API key) ---
const categoryBaseUrls: { [key: string]: string } = {
    Politics: "https://newsapi.org/v2/everything?q=Politics&sortBy=popularity",
    Economics: "https://newsapi.org/v2/everything?q=Economics&sortBy=popularity",
    Business: "https://newsapi.org/v2/everything?q=Business&sortBy=popularity",
    Technology: "https://newsapi.org/v2/everything?q=Technology&sortBy=popularity",
    Sports: "https://newsapi.org/v2/everything?q=Sports&sortBy=popularity",
};

// --- Category Click Handlers (corrected URL usage) ---
Object.keys(categoryBaseUrls).forEach(category => {
    document.getElementById(category)?.addEventListener("click", async () => {
        const headLinesTitle = document.getElementById("HeadLinesTitle"); // Make sure this element exists in your HTML
        if (headLinesTitle) headLinesTitle.innerHTML = category;
        // Call getHeadLines with the base URL; the function will append the API key
        await getHeadLines(categoryBaseUrls[category]);
    });
});



document.getElementById("InputImg")?.addEventListener("click", async ()=>{
    let value = (document.getElementById("Input") as HTMLInputElement)?.value;
    await getHeadLines(`https://newsapi.org/v2/everything?q=${value}&apiKey=b78309736d734341b5169baceb654854`)
    const headLinesTitle = document.getElementById("HeadLinesTitle"); // Make sure this element exists in your HTML
        if (headLinesTitle) headLinesTitle.innerHTML = value;
    
})

