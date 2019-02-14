import React, { Component } from "react";
class Validation extends Component {
  render() {
    return (
      <React.Fragment>
        <script src="lib/jquery-validation/dist/jquery.validate.js"></script>
        <script src="lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"></script>
      </React.Fragment>
    );
  }
}
export default Validation;
