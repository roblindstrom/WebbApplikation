import React, { Component } from "react";
import { Link } from 'react-router-dom';

export class AllCategoriesCard extends Component {
 
  render() {
    return (
      
      <div>
        <Link tag={Link} type="button" className="ListOfCategories" to={"/Categories/name/" + this.props.categoryName} > {this.props.categoryName}</Link>
          </div>
        
        
    );
  }
}