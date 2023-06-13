import { createSlice } from "@reduxjs/toolkit";

export const authSlice = createSlice({
  name: "auth",
  initialState: {
    user: null,
  },
  reducers: {
    setUser: (state, action) => {
      state.user = action.payload;
    },
    cleanUser: (state) => {
      state.user = null;
    },
  },
});

export const { setUser, cleanUser } = authSlice.actions;
