
namespace OfficeOpenXml.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Xml;

    using iTin.Core.Helpers;

    /// <summary>
    /// A Specialization of <see cref="IXmlHelper"/> interface.<br/>
    /// Allows manipulate a <b>XML</b> document.
    /// </summary>
    internal class XmlBaseHelper : IXmlHelper
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XmlDocument _document;

        #endregion

        #region interfaces

        #region IXmlHelper 

        #region explicit

        IXmlHelper IXmlHelper.Instance => Instance;

        #endregion

        #region public properties

        #region [public] (XmlDocument) ChartXmlDocument: Gets or sets the drawing XML from an EPPlus document
        /// <summary>
        /// Gets or sets the drawing <b>XML</b> from an <b>EPPlus</b> document.
        /// </summary>
        /// <value>
        /// <see cref="XmlDocument"/> reference that contains the <b>EPPlus</b> drawing <b>XML</b> document.
        /// </value>
        public XmlDocument XmlDocument
        {
            get => _document;
            set
            {
                _document = value;
                ResolveNamespaceManager();
            }
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (XmlAttribute) CreateAttribute(string): Create a new attribute for this document
        /// <summary>
        /// Create a new attribute for this document.
        /// </summary>
        /// <param name="name">Attribute name.</param>
        /// <returns>
        /// <see cref="XmlAttribute"/> reference that contains a new attribute.
        /// </returns>
        public XmlAttribute CreateAttribute(string name) => XmlDocument.CreateAttribute(name);
        #endregion

        #region [public] (XmlElement) CreateElement(string, string): Creates an element with the specified Prefix, and LocalName
        /// <summary>
        /// Creates an element with the specified Prefix, and LocalName.
        /// </summary>
        /// <param name="prefix">The prefix of the new element.</param>
        /// <param name="localName">The local name of the new element.</param>
        /// <returns>
        /// The new <see cref="XmlElement"/>.
        /// </returns>
        public XmlElement CreateElement(string prefix, string localName) => CreateElement(prefix, localName, NamespaceManager.LookupNamespace(prefix));

        #endregion

        #region [public] (XmlElement) CreateElement(string, string, string): Creates an element with the specified Prefix, LocalName, and NamespaceURI
        /// <summary>
        /// Creates an element with the specified Prefix, LocalName, and NamespaceURI.
        /// </summary>
        /// <param name="prefix">The prefix of the new element.</param>
        /// <param name="localName">The local name of the new element.</param>
        /// <param name="namespaceUri">The namespace URI of the new element.</param>
        /// <returns>
        /// The new <see cref="XmlElement"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">If <paramref name="prefix"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="prefix"/> length is less than 1.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="localName"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="localName"/> length is less than 1.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="namespaceUri"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="namespaceUri"/> length is less than 1.</exception>
        public XmlElement CreateElement(string prefix, string localName, string namespaceUri)
        {
            SentinelHelper.ArgumentNull(prefix, nameof(prefix));
            SentinelHelper.IsTrue(prefix.Length < 1, "The minimum length must be 1");

            SentinelHelper.ArgumentNull(localName, nameof(localName));
            SentinelHelper.IsTrue(localName.Length < 1, "The minimum length must be 1");

            SentinelHelper.ArgumentNull(namespaceUri, nameof(namespaceUri));
            SentinelHelper.IsTrue(namespaceUri.Length < 1, "The minimum length must be 1");

            return XmlDocument.CreateElement(prefix, localName, namespaceUri);
        }
        #endregion

        #region [public] (XmlNode) CreateOrDefaultAndAppendElementToNode(string): Create or return an element with the specified name, and adds it to the document root node
        /// <summary>
        /// Create or return an element with the specified name, and adds it to the document root node.
        /// </summary>
        /// <param name="name">The name of the new element.</param>
        /// <returns>
        /// Return if it already exists, else it is created and added to the root node.
        /// </returns>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> length is less than 1.</exception>
        public XmlNode CreateOrDefaultAndAppendElementToNode(string name) => CreateOrDefaultAndAppendElementToNode((XmlNode)null, name);
        #endregion

        #region [public] (XmlNode) CreateOrDefaultAndAppendElementToNode(string, string): Create or return an element with the specified Prefix and LocalName, and adds it to the document root node
        /// <summary>
        /// Create or return an element with the specified Prefix and LocalName, and adds it to the document root node.
        /// </summary>
        /// <param name="prefix">The prefix of the new element.</param>
        /// <param name="localName">The local name of the new element.</param>
        /// <returns>
        /// Return if it already exists, else it is created and added to the root node.
        /// </returns>
        public XmlNode CreateOrDefaultAndAppendElementToNode(string prefix, string localName) => CreateOrDefaultAndAppendElementToNode(prefix, localName, NamespaceManager.LookupNamespace(prefix));
        #endregion

        #region [public] (XmlNode) CreateOrDefaultAndAppendElementToNode(string, string, string): Create or return an element with the specified Prefix, LocalName and NamespaceUri, and adds it to the document root node
        /// <summary>
        /// Create or return an element with the specified Prefix, LocalName and NamespaceUri, and adds it to the document root node.
        /// </summary>
        /// <param name="prefix">The prefix of the new element.</param>
        /// <param name="localName">The local name of the new element.</param>
        /// <param name="namespaceUri">The namespace URI of the new element.</param>
        /// <returns>
        /// The new <see cref="XmlNode"/>.
        /// </returns>
        public XmlNode CreateOrDefaultAndAppendElementToNode(string prefix, string localName, string namespaceUri) => CreateOrDefaultAndAppendElementToNode(null, prefix, localName, namespaceUri);
        #endregion

        #region [public] (XmlNode) CreateOrDefaultAndAppendElementToNode(XmlNode, string): Create or return an element with the specified name, and adds it to the document in the specified node
        /// <summary>
        /// Create or return an element with the specified name, and adds it to the document in the specified node.
        /// </summary>
        /// <param name="root">The root node of new element.</param>
        /// <param name="name">The name of the new element.</param>
        /// <returns>
        /// Return if it already exists, else it is created and added to the specified node.
        /// </returns>
        /// <exception cref="ArgumentNullException">If <paramref name="root"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> length is less than 3.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> contains white spaces.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> has not correct format.</exception>
        public XmlNode CreateOrDefaultAndAppendElementToNode(XmlNode root, string name)
        {
            SentinelHelper.ArgumentNull(root, nameof(root));
            SentinelHelper.IsTrue(name.Length <= 3, "El parametro element debe contener al menos tres caracteres");
            SentinelHelper.IsTrue(string.IsNullOrEmpty(name), "El parametro element no puede estar en blanco");
            SentinelHelper.IsFalse(name.Contains(":"), "El formato no es correcto. Se esperaba prefijo:localname");
            SentinelHelper.IsTrue(name.Contains(" "), "El formato no es correcto. No se permiten espacios en el elemento");

            var piece = name.Split(':');
            var prefix = piece[0];
            var localName = piece[1];

            return CreateOrDefaultAndAppendElementToNode(root, prefix, localName, NamespaceManager.LookupNamespace(prefix));
        }
        #endregion

        #region [public] (XmlNode) CreateOrDefaultAndAppendElementToNode(XmlNode, string, string): Create or return an element with the specified Prefix and LocalName, and adds it to the document in the specified node
        /// <summary>
        /// Create or return an element with the specified Prefix and LocalName, and adds it to the document in the specified node.
        /// </summary>
        /// <param name="root">The root node of new element.</param>
        /// <param name="prefix">The prefix of the new element.</param>
        /// <param name="localName">The local name of the new element.</param>
        /// <returns>
        /// Return if it already exists, else it is created and added to the specified node.
        /// </returns>
        public XmlNode CreateOrDefaultAndAppendElementToNode(XmlNode root, string prefix, string localName) => CreateOrDefaultAndAppendElementToNode(root, prefix, localName, NamespaceManager.LookupNamespace(prefix));
        #endregion

        #region [public] (XmlNode) CreateOrDefaultAndAppendElementToNode(XmlNode, string, string, string): Create or return an element with the specified Prefix, LocalName and NamespaceUri, and adds it to the document in the specified node
        /// <summary>
        /// Create or return an element with the specified Prefix, LocalName and NamespaceUri, and adds it to the document in the specified node.
        /// </summary>
        /// <param name="root">The root node of new element.</param>
        /// <param name="prefix">The prefix of the new element.</param>
        /// <param name="localName">The local name of the new element.</param>
        /// <param name="namespaceUri">The namespace URI of the new element.</param>
        /// <returns>
        /// The new <see cref="XmlNode"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">If <paramref name="root"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="prefix"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="prefix"/> length is less than 1.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="localName"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="localName"/> length is less than 1.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="namespaceUri"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="namespaceUri"/> length is less than 1.</exception>
        public XmlNode CreateOrDefaultAndAppendElementToNode(XmlNode root, string prefix, string localName, string namespaceUri)
        {
            SentinelHelper.ArgumentNull(root, nameof(root));

            SentinelHelper.ArgumentNull(prefix, nameof(prefix));
            SentinelHelper.IsTrue(prefix.Length < 1, "The minimum length must be 1");

            SentinelHelper.ArgumentNull(localName, nameof(localName));
            SentinelHelper.IsTrue(localName.Length < 1, "The minimum length must be 1");

            SentinelHelper.ArgumentNull(namespaceUri, nameof(namespaceUri));
            SentinelHelper.IsTrue(namespaceUri.Length < 1, "The minimum length must be 1");

            var element = new StringBuilder();
            element.Append(prefix);
            element.Append(":");
            element.Append(localName);

            var exist = HasElement(root, element.ToString());
            var tempNode = exist ? 
                GetXmlNode(root, element.ToString()) : 
                CreateElement(prefix, localName, namespaceUri);

            if (root == null)
            {
                XmlDocument.AppendChild(tempNode);
            }
            else
            {
                root.AppendChild(tempNode);
            }

            return tempNode;
        }
        #endregion

        #region [public] (IEnumerable<XmlNode>) GetElementsByTagName(string): Returns an reference than containing a list of all descendant elements that match the specified name
        /// <summary>
        /// Returns an reference than containing a list of all descendant elements that match the specified name.
        /// </summary>
        /// <param name="name">The qualified name to match. It is matched against the <b>Name</b> property of the matching node. The special value "*" matches all tags.</param>
        /// <returns>
        /// A list of all matching nodes. If no nodes match name, the returned collection will be empty.
        /// </returns>
        public IEnumerable<XmlNode> GetElementsByTagName(string name) => XmlDocument.GetElementsByTagName(name).Cast<XmlNode>().ToList();

        #endregion

        #region [public] (XmlNode) GetXmlNode(string): Selects the first XmlNode that matches the XPath expression in root node
        /// <summary>
        /// Selects the first <see cref="XmlNode"/> that matches the XPath expression in root node.
        /// </summary>
        /// <param name="path">XPath expression.</param>
        /// <returns>
        /// The first <see cref="XmlNode"/> that matches the XPath query or <b>null</b> if no matching node is found.
        /// </returns>
        public XmlNode GetXmlNode(string path) => GetXmlNode(null, path);
        #endregion

        #region [public] (XmlNode) GetXmlNode(XmlNode, string): Selects the first XmlNode that matches the XPath expression in the specified node
        /// <summary>
        /// Selects the first <see cref="XmlNode"/> that matches the XPath expression in the specified node.
        /// </summary>
        /// <param name="root">The root node.</param>
        /// <param name="path">XPath expression.</param>
        /// <returns>
        /// The first <see cref="XmlNode"/> that matches the XPath query or <b>null</b> if no matching node is found.
        /// </returns>
        public XmlNode GetXmlNode(XmlNode root, string path) => root == null ? XmlDocument.SelectSingleNode(path, NamespaceManager) : root.SelectSingleNode(path, NamespaceManager);
        #endregion

        #region [public] (bool) HasElement(string): Determines whether the specified element exist in the root node
        /// <summary>
        /// Determines whether the specified element exist in the root node.
        /// </summary>
        /// <param name="name">The element name.</param>
        /// <returns>
        /// <b>true</b> if exist; otherwise, <b>false</b>.
        /// </returns>
        public bool HasElement(string name) => HasElement(null, name);
        #endregion

        #region [public] (bool) HasElement(XmlNode, string): Determines whether the specified element exist in the specified node
        /// <summary>
        /// Determines whether the specified element exist in the specified node.
        /// </summary>
        /// <param name="root">The root node.</param>
        /// <param name="name">The element name.</param>
        /// <returns>
        /// <b>true</b> if exist; otherwise, <b>false</b>.
        /// </returns>
        public bool HasElement(XmlNode root, string name) => root == null ? GetXmlNode(XmlDocument, name) != null : GetXmlNode(root, name) != null;
        #endregion

        #region [public] (bool) TryGetElementFrom(XmlNode, string, out XmlNode): Try to get the item in the specified node if exist is returned in the parameter node, otherwise will contain null, if the operation is performed returns true
        /// <summary>
        /// Try to get the item in the specified node if exist is returned in the parameter <paramref name="node"/>, otherwise will contain <b>null</b>, if the operation is performed returns <b>true</b>.
        /// </summary>
        /// <param name="root">The root node of new element.</param>
        /// <param name="name">The element name.</param>
        /// <param name="node">The output node.</param>
        /// <returns>
        /// <b>true</b> if exist; otherwise, <b>false</b>.
        /// </returns>
        /// <exception cref="ArgumentNullException">If <paramref name="root"/> is <b>null</b>.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> length is less than 3.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> contains white spaces.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> has not correct format.</exception>
        public bool TryGetElementFrom(XmlNode root, string name, out XmlNode node)
        {
            SentinelHelper.ArgumentNull(root, nameof(root));
            SentinelHelper.IsTrue(name.Length <= 3, "The element parameter must contain at least three characters");
            SentinelHelper.IsTrue(string.IsNullOrEmpty(name), "The element parameter cannot be blank");
            SentinelHelper.IsFalse(name.Contains(":"), "The format is not correct. Prefix expected: localname");
            SentinelHelper.IsTrue(name.Contains(" "), "The format is not correct. Spaces are not allowed in the element");

            var exist = HasElement(root, name);
            if (exist)
            {
                node = GetXmlNode(root, name);
            }
            else
            {
                var piece = name.Split(':');
                var prefix = piece[0];
                var localName = piece[1];

                node = CreateElement(prefix, localName);
            }

            return exist;
        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region protected static properties
        protected static readonly XmlBaseHelper Instance = new XmlBaseHelper();
        #endregion

        #region protected virtual readonly properties

        #region [protected] {virtual} (XmlNamespaceManager) NamespaceManager: Gets or sets a reference to the namespace manager for this XML document
        /// <summary>
        /// Gets or sets a reference to the namespace manager for this <b>XML</b> document.
        /// </summary>
        /// <value>
        /// <see cref="XmlNamespaceManager"/> reference that contains the namespace list.
        /// </value>
        protected virtual XmlNamespaceManager NamespaceManager { get; set; }
        #endregion

        #endregion

        #region public static methods

        public static IXmlHelper GetInstance() => Instance;

        #endregion

        #region protected virtual methods

        protected virtual void ResolveNamespaceManager()
        {
            if (NamespaceManager == null)
            {
                NamespaceManager = new XmlNamespaceManager(_document.NameTable);
            }
        }

        #endregion
    }
}
