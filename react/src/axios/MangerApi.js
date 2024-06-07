import axios from "axios";
axios.defaults.baseURL = "https://localhost:7146";


export async function loginManager(name_manager, password)
{
    try {
        return await axios.get("/Manager/get",{       //(name_manager,password)      
        }      
        ).then(function(response){
            console.log(response);
            return response
        })
    }
    catch(error)
    {
        console.log(error);
    };
}
    

export async function FinishPurchase() {
    try {
        return await axios.put(`/Purchase/finishPurchase${1}`)
            .then(function (response) {
                console.log(response);
                return response
            })
    }
    catch (error) {
        console.log(error);
    };
}
export async function DeletePresent(id_p){
    return await axios.delete(`/Present/${id_p}`)
    .then(function (response) {
        console.log(response);
        return response
    })    
}
// export async function DeleteSeveralPresents(presents){
//     return await axios.delete(`/Present/deleteSeveralPresents${presents}`)
//     .then(function (response) {
//         console.log(response);
//         return response
//     })    
// }


export async function DeleteSeveralPresents(presents) {
    return await axios.delete('/Present/deleteSeveralPresents', {
      data: presents
    })
    .then(function (response) {
      console.log(response);
      return response;
    })
    .catch(function (error) {
      console.error("There was an error deleting the presents!", error);
      throw error;
    });
  }

