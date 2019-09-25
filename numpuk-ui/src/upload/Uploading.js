import React, { Component } from "react";
import { HubConnectionBuilder } from "@microsoft/signalr";
import styled from "styled-components";

const Container = styled.div`
  margin: 100px;
  background-color: gray;
`;

export class Uploading extends Component {
  constructor(props) {
    super(props);
    this.state = { hubConnection: null, message: "" };
  }

  componentDidMount = () => {
    const hubConnection = new HubConnectionBuilder()
      .withUrl("https://localhost:44392/filesHub")
      .build();

    this.setState({ hubConnection }, () => {
      this.state.hubConnection
        .start()
        .then(() => {
          console.log("Connection started!");
          this.state.hubConnection
            .invoke("SendFiles", this.props.files)
            .catch(err => console.error(err));
        })
        .catch(err => console.log("Error while establishing connection :("));

      this.state.hubConnection.on("FilesAccepted", messageFromServer => {
        console.log(messageFromServer);
        this.setState({ message: messageFromServer });
      });
    });
  };

  render() {
    return (
      <Container>
        <div>{this.state.message}</div>
      </Container>
    );
  }
}
