import React, { Component } from "react";
import Validation from "../validation";

class ProductList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: []
    };
    this.reload = this.reload.bind(this);
  }

  componentDidMount() {
    this.reload();
    this.props.setReload(this.reload);
  }

  reload() {
    fetch("http://localhost:5000/api/products")
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            isLoaded: true,
            items: result
          });
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        error => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      );
  }

  render() {
    const { error, isLoaded, items } = this.state;
    if (error) {
      return <p>Error: {error.message}</p>;
    } else if (!isLoaded) {
      return <p>Loading...</p>;
    } else {
      return (
        <ul>
          {
            items.map(item => (
              <li key={item.id}>
                {item.name} - {item.category} -> 
                <button
                  onClick={() => this.props.loadForUpdate(item)}
                >
                  update
                </button>
                <button
                  onClick={() => this.props.delete(item.id)}
                >
                  delete
                </button>
              </li>
            ))
          }
        </ul>
      );
    }
  }
}

class Products extends Component {
  constructor(props) {
    super(props);
    this.state = {
      updatingItem: null,
      originalItem: null,
      reloadMethod: null,
      validateError: null,
    }
    this.delete = this.delete.bind(this);
    this.loadForUpdate = this.loadForUpdate.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleCancel = this.handleCancel.bind(this);
    this.setReload = this.setReload.bind(this);
  }

  delete(id) {
    const confirmResult = window.confirm('Are you sure?');
    if (confirmResult) {
      // Perform the delete
      fetch("http://localhost:5000/api/products/" + id, {
        method: "DELETE",
      })
        .then(response => this.state.reloadMethod())
        .catch(err => console.log(err));
    }
  }

  loadForUpdate(item) {
      let itemCopy = {
      id: item.id,
      name: item.name,
      category: item.category,
    }

    this.setState({
      updatingItem: itemCopy,
      originalItem: item,
      validateError: null,
    });
  }

  setReload(reloadMethod) {
    this.setState(
      { reloadMethod: reloadMethod }
    );
  }

  handleCancel = event => {
    event.preventDefault();
    this.setState(
      {
        updatingItem: null,
        originalItem: null,
        validateError: null,
      }
    );
  }

  handleSubmit = event => {
    event.preventDefault();
    const item = this.state.updatingItem;

    // Validation
    if (!item.name) {
      this.setState({
        validateError: 'The name is required',
      })
      return;
    }

    let postData = {
      Name: item.name,
      Category: item.category
    };

    // Perform the update
    fetch("http://localhost:5000/api/products/" + this.state.updatingItem.id, {
      method: "PUT",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      mode: "cors",
      body: JSON.stringify(postData)
    })
      .then(response => this.state.reloadMethod())
      .then(this.setState(
        {
          updatingItem: null,
          originalItem: null,
        }
      ))
    .catch(err => console.log(err));
  };

  handleInputChange = event => {
    const target = event.target;
    const value = target.type === "checkbox" ? target.checked : target.value;
    const name = target.name;

    const item = this.state.updatingItem;

    let itemCopy = {
      id: item.id,
      name: item.name,
      category: item.category,
    }
    if (name === 'Name')
      itemCopy.name = value;
    if (name === 'Category')
      itemCopy.category = value;

    if (itemCopy.name) {
      this.setState({
        validateError: null,
      });
    }

    this.setState({
      updatingItem: itemCopy,
    });
  };

  render() {
    return (
      <React.Fragment>
        <h1 className="display-4">Products</h1>
        <ProductList loadForUpdate={this.loadForUpdate} setReload={this.setReload} delete={this.delete} />
        {this.updateProduct()}
        <Validation />
      </React.Fragment>
    );
  }

  updateProduct() {
    if (this.state.updatingItem) {
      const item = this.state.updatingItem;
      return (
        <form onSubmit={this.handleSubmit}>
          <h4>Update product</h4>
          <div className="text-danger field-validation-valid">{this.state.validateError}</div>
          <div className="form-group">
            <label className="control-label" htmlFor="Name">
              Name
          </label>
            <input
              className="form-control"
              type="text"
              id="Name"
              name="Name"
              onChange={this.handleInputChange}
              value={item.name}
              data-val="true"
              data-val-required="The Name field is required."
            />
            <span
              className="text-danger field-validation-valid"
              data-valmsg-for="Name"
              data-valmsg-replace="true"
            />
          </div>
          <div className="form-group">
            <label className="control-label" htmlFor="Category">
              Category
          </label>
            <input
              className="form-control"
              type="text"
              id="Category"
              name="Category"
              onChange={this.handleInputChange}
              value={item.category}
            />
            <span
              className="text-danger field-validation-valid"
              data-valmsg-for="Category"
              data-valmsg-replace="true"
            />
          </div>
          <div className="form-group">
            <button className="btn btn-primary">Submit</button>
            &nbsp;&nbsp;
            <button className="btn btn-secondary" onClick={this.handleCancel}>Cancel</button>
          </div>
          <Validation />
        </form>
        );
    }
    else
      return 'Click an update button above to update a product.';
  }
}
export default Products;
