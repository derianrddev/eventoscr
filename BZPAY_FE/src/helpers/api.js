const origin = "https://localhost:3000";

const myHeaders = {
  "Content-Type": "application/json",
  "Access-Control-Allow-Origin": origin,
};

export const getRequest = async (url) => {
  const settings = {
    method: "get",
    headers: myHeaders,
  };

  try {
    const response = await fetch(url, settings);
    const data = await response.json();

    if (response.status !== 200) {
      return {
        ok: false
      };
    }

    return {
      ok: true,
      data
    };
  } catch (error) {
    return {
      ok: false
    };
  }
};

export const postRequestUrl = async (url) => {
  const settings = {
    method: "post",
    headers: myHeaders,
  };

  try {
    const response = await fetch(url, settings);
    const data = await response.json();

    if (response.status !== 200) {
      return {
        ok: false
      };
    }

    return {
      ok: true,
      data
    };
  } catch (error) {
    return {
      ok: false
    };
  }
};

export const getUserDetails = async (userId) => {
  const url = `https://localhost:7052/api/User/GetDetalleUsuariosById/${userId}`;
  const result = await getRequest(url);

  if (result.ok) {
    localStorage.setItem('roleName', result.data.roleName);
  }
};
