import React, { Component } from 'react'
import './Css/StarRating.css';
import './Css/AddRestaurant.css';
import Axios from 'axios';

export default class AddRestaurant extends Component {
  constructor(props) {
    super(props);
    this.state = {
      categories: [],
      loading: true,
      selectedCategory: "Category",
      chosenCategory: "Category",
    };
    this.addRestaurantRequest = this.addRestaurantRequest.bind(this);
    this.CreateDropdownMenu = this.CreateDropdownMenu.bind(this);
    this.setCategoryChange = this.setCategoryChange.bind(this);
    
  }

  componentDidMount() {
    Axios.get('api/categories')
      .then(res => {
        this.setState({
          categories: res.data,
          loading: false
        })

      })
  }

  CreateDropdownMenu() {
    let elements = [];
    for (let category of this.state.categories) {
      elements.push(<option key={category.categoryName} value={category.categoryName}>{category.categoryName}</option>)
    }
    return (elements);
  }
  setCategoryChange(event) {
    let category = event.target.value;
    this.setState({
      selectedCategory: category
    });
    
  }
  render() {

    let DropdownOptions = this.state.loading ? <p>Loading...</p> : this.CreateDropdownMenu()
        return (
            <div>
            <div>
                <br />
                <h1 className="Header">Add a restaurant</h1>
            </div>
            <div>
                <form id="addForm">
                    <input 
                    data-cy="addRestaurantName"
                  id="restaurantName" 
                    type="text"
                    placeholder=" Restaurant name:" />
                <br />
                <input
                  data-cy="addImageUrl"
                  id="imageUrl"
                  type="text"
                  placeholder="ImageUrl:" />
                <br />
                <input
                  data-cy="addRestaurantlink"
                  id="restaurantlink"
                  type="text"
                  name="restaurant"
                  placeholder=":Restaurant Websitelink" />
                <br />
                   <div>
                  <select
                    ref="selectOption"
                    onChange={(e) => this.setCategoryChange(e)}
                    data-cy="addCategory"
                    id="category" 
                    type="text" 
                    name="Category">
                        <option value="option">Category</option>
                         {DropdownOptions}
                  </select>
                  <textarea
                    data-cy="addDescription"
                    id="restaurantDescription"
                    placeholder=" Write the restaurant description here..."></textarea>
                  </div>
                <button
                  type="button"
                  data-cy="submitAddRestaurant"
                  className="btn btn-primary"
                  onClick={ () => this.addRestaurantRequest() }>Add Restaurant</button>
                </form>
            </div>
            </div>
        )
  }

   addRestaurantRequest() {

    let restaurantName = document.getElementById("restaurantName").value;
    let imageUrl = document.getElementById("imageUrl").value;
    let restaurantlink = document.getElementById("restaurantlink").value;
    let description = document.getElementById("restaurantDescription").value;

     

    Axios({
      method: 'post',
      url: "/api/Restaurants",
      data: {
        RestaurantLink: restaurantlink,
        TempImage: imageUrl,
        RestaurantName: restaurantName ,
        Description: description ,
        RestaurantName: restaurantName,
        
      },
    }).then(res => {
      if (res.status === 200) {
        Axios({
          method: 'post',
          url: "/api/Restaurants/addCategory",
          data: {
            CategoryName: this.state.selectedCategory,
            RestaurantName: restaurantName,

          },

        });
        Axios({
          method: 'post',
          url: "/api/categories/addRestaurant",
          data: {
            CategoryName: this.state.selectedCategory,
            RestaurantName: restaurantName,

          },

        })

      }
   
    })
      
        
  }
}
