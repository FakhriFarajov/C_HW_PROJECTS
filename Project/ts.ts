let loadingAnim = document.getElementById("Loading");
 
let list: any[] = [];
 
interface ApiConfig {
    api: string; // The key in your JSON is 'api'
}
 
 
 
async function getApi(){
    try {
        const response = await fetch('api.json');
        const json: ApiConfig = await response.json(); // Type the JSON response
        return json.api;
    } catch (error) {
        console.error("Error loading API key from api.json:", error);
        if (document.getElementById("headlinesContainer")) { // Assuming you have this ID for the main content area
            document.getElementById("headlinesContainer")!.innerHTML = "<div>Error loading API configuration. News cannot be displayed.</div>";
        }
    }
}
 
// --- getHeadLines function (corrected URL construction) ---
async function getHeadLines(baseUrl: string) {
    // --- IMPORTANT: Check if API key is loaded before making the fetch call ---
    if (!await getApi()) {
        console.error("API Key not loaded yet. Cannot fetch headlines.");
        if (loadingAnim) loadingAnim.style.display = "none";
        // Optionally display a message to the user that the API key isn't ready
        return;
    }
 
    try {
        if (loadingAnim) loadingAnim.style.display = "flex";
       
        // --- Correctly construct the URL by appending the loaded API key ---
        const url = `${baseUrl}&apiKey=${await getApi()}`;
       
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
                renderNews();
 
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
 
function renderNews() {
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
            renderNews();
        }
    });
 
if (nextBtn)
    nextBtn.addEventListener("click", () => {
        const totalPages = Math.ceil(list.length / itemsPerPage);
        if (currentPage < totalPages) {
            currentPage++;
            renderNews();
        }
    });
 
document.addEventListener("DOMContentLoaded", async () => {
    while (!await getApi()) {
        await new Promise(resolve => setTimeout(resolve, 50)); // Wait a bit
    }
    console.log("Initial fetch triggered.");
    await getHeadLines(`https://newsapi.org/v2/top-headlines?country=us`); // getHeadLines will append the key
});
 
const categoryBaseUrls: { [key: string]: string } = {
    Politics: "https://newsapi.org/v2/everything?q=Politics&sortBy=popularity",
    Economics: "https://newsapi.org/v2/everything?q=Economics&sortBy=popularity",
    Business: "https://newsapi.org/v2/everything?q=Business&sortBy=popularity",
    Technology: "https://newsapi.org/v2/everything?q=Technology&sortBy=popularity",
    Sports: "https://newsapi.org/v2/everything?q=Sports&sortBy=popularity",
};
 
Object.keys(categoryBaseUrls).forEach(category => {
    document.getElementById(category)?.addEventListener("click", async () => {
        const headLinesTitle = document.getElementById("HeadLinesTitle"); // Make sure this element exists in your HTML
        if (headLinesTitle) headLinesTitle.innerHTML = category;
        await getHeadLines(categoryBaseUrls[category]);
    });
});
 
 
document.getElementById("InputImg")?.addEventListener("click", async () => {
    const inputElement = document.getElementById("Input") as HTMLInputElement;
    let value: string = "";
    if (inputElement.value) {
        value = inputElement.value;
        inputElement.value = "";
    }
    else{
        return
    }
    value = value.trim()

    await getHeadLines(`https://newsapi.org/v2/everything?q=${value}&apiKey=${await getApi()}`);
 
    const headLinesTitle = document.getElementById("HeadLinesTitle");
 
    if (headLinesTitle) {
        headLinesTitle.innerHTML = value;
    }
});
  
document.getElementById("LogoImg")?.addEventListener("click", async ()=>{
    await getHeadLines(`https://newsapi.org/v2/top-headlines?country=us`);
    const headLinesTitle = document.getElementById("HeadLinesTitle"); // Make sure this element exists in your HTML
    if (headLinesTitle) headLinesTitle.innerHTML = "HeadLines";
})

document.getElementById("Input")?.addEventListener("keypress", async (e) => {
    if(e.key != "Enter") return 
    const inputElement = document.getElementById("Input") as HTMLInputElement;
    let value: string = "";
    if (inputElement.value) {
        value = inputElement.value;
        inputElement.value = "";
    }
    else return
    value = value.trim()

    await getHeadLines(`https://newsapi.org/v2/everything?q=${value}&apiKey=${await getApi()}`);
 
    const headLinesTitle = document.getElementById("HeadLinesTitle");
 
    if (headLinesTitle) {
        headLinesTitle.innerHTML = value;
    }
});