const total1 = document.querySelector('.TotalPage');
var a = async () => {
    const url = 'https://localhost:7111/ImageAPIGateway/Image/TotalCountImages';
    try {
        const response = await fetch(url);
        const data = await response.json();
        const res = data;
        total1.textContent = res.total
    }   
    catch (error) {
        console.error('Error:', error);
    }
}
a();

async function getApiResult(page) {
    const url = `https://localhost:7111/ImageAPIGateway/Image/GetImageByPageNumber?page=${page}`;
    console.log(page)
    try {
        const response = await fetch(url);
        const data = await response.json();
        const res = data;
        return res;  
    }   
    catch (error) {
        console.error('Error:', error);
    }
  }

function EditUrls(page){
    getApiResult(page).then(res => {
        let index = 1
        res.forEach(element => {
            if(index === 1){
                const formattedURL = element.imageURL.replace(/\\/g, '/');
                const image1 = document.getElementById('image1');
                image1.src = formattedURL
            }
            else if(index === 2){
                const formattedURL = element.imageURL.replace(/\\/g, '/');
                const image2 = document.getElementById('image2');
                image2.src = formattedURL
            }
            index++;
        });
      });

}

const pageSpan = document.querySelector('.Page');
EditUrls(+(pageSpan.textContent));    

document.querySelector('.paginate.left').onclick = function() {
    let pageSpanNumber = document.querySelector('.Page');
    if((+pageSpanNumber.textContent) >= 2){
        let temp = (+pageSpanNumber.textContent) - 1;
        pageSpan.textContent = temp
    }
};

document.querySelector('.paginate.right').onclick = function() {
    let pageSpanNumber = document.querySelector('.Page');
    const total = document.querySelector('.TotalPage');
    if(((+pageSpanNumber.textContent) >= 1) && ((+pageSpanNumber.textContent)) < (+total.textContent)){
        let temp = (+pageSpanNumber.textContent) + 1;
        pageSpan.textContent = temp
    }
};





  

  
  